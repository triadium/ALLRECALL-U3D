using System;
using System.Linq;
using ParadoxNotion;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;

namespace NodeCanvas.Framework.Internal{

	///Handles missing Node serialization and recovery
	public class fsNodeProcessor : fsObjectProcessor {

		public override bool CanProcess(Type type){
			return typeof(Node).RTIsAssignableFrom(type);
		}

		public override void OnBeforeSerialize(Type storageType, object instance){}
		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data){}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data){

			if (data.IsNull)
				return;

			var json = data.AsDictionary;

			fsData typeData;
			if (json.TryGetValue("$type", out typeData)){

				var serializedType = ReflectionTools.GetType( typeData.AsString );

				//Handle missing serialized Node type
				if (serializedType == null){

					//try find defined [DeserializeFrom] attribute
					foreach(var type in ReflectionTools.GetAllTypes()){
						var att = type.RTGetAttribute<DeserializeFromAttribute>(false);
						if (att != null && att.previousTypeNames.Any(n => n == typeData.AsString) ){
							json["$type"] = new fsData( type.FullName );
							return;
						}
					}

					//inject the 'MissingNode' type and store recovery serialization state
					json["recoveryState"] = new fsData( data.ToString() );
					json["missingType"] = new fsData( typeData.AsString );
					json["$type"] = new fsData( typeof(MissingNode).FullName );
				}

				//Recover possible found serialized type
				if (serializedType == typeof(MissingNode)){

					//try find defined [DeserializeFrom] attribute
					foreach(var type in ReflectionTools.GetAllTypes()){
						var att = type.RTGetAttribute<DeserializeFromAttribute>(false);
						if (att != null && att.previousTypeNames.Any(n => n == json["missingType"].AsString) ){
							json["$type"] = new fsData( type.FullName );
							return;
						}
					}

					//Does the missing type now exists? If so recover
					var missingType = ReflectionTools.GetType( json["missingType"].AsString );
					if (missingType != null){

						var recoveryState = json["recoveryState"].AsString;
						var recoverJson = fsJsonParser.Parse(recoveryState).AsDictionary;

						//merge the recover state *ON TOP* of the current state, thus merging only Declared recovered members
						json = json.Concat( recoverJson.Where( kvp => !json.ContainsKey(kvp.Key) ) ).ToDictionary( c => c.Key, c => c.Value );
						json["$type"] = new fsData( missingType.FullName );
						data = new fsData( json );
					}
				}
			}
		}

		public override void OnAfterDeserialize(Type storageType, object instance){}
	}
}