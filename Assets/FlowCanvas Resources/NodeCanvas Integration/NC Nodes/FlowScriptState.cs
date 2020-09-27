using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

using FlowCanvas;

namespace NodeCanvas.StateMachines{

	[Name("FlowScript")]
	[Category("Nested")]
	[Description("Adds a FlowCanvas FlowScript as a nested State of the FSM. The FlowScript State is never finished by itself, thus OnFinish transitions are never called from this state.")]
	public class FlowScriptState : FSMState, IGraphAssignable{

		[SerializeField]
		private BBParameter<FlowScript> _flowScript;

		private Dictionary<FlowScript, FlowScript> instances = new Dictionary<FlowScript, FlowScript>();

		public FlowScript flowScript{
			get {return _flowScript.value;}
			set {_flowScript.value = value;}
		}

		public Graph nestedGraph{
			get {return flowScript;}
			set {flowScript = (FlowScript)value;}
		}
/*
		protected override void OnInit(){
			if (flowScript != null){
				CheckInstance();
			}
		}
*/
		protected override void OnEnter(){

			if (flowScript == null){
				Finish(false);
				return;
			}

			CheckInstance();

			flowScript.StartGraph(graphAgent, graphBlackboard, Finish );
		}

		protected override void OnUpdate(){

		}

		protected override void OnExit(){
			if (IsInstance(flowScript) && flowScript.isRunning)
				flowScript.Stop();
		}

		protected override void OnPause(){
			if (IsInstance(flowScript) && flowScript.isRunning)
				flowScript.Pause();
		}

		bool IsInstance(FlowScript fs){
			return instances.Values.Contains(fs);
		}

		void CheckInstance(){

			if (IsInstance(flowScript)){
				return;
			}

			FlowScript instance = null;
			if (!instances.TryGetValue(flowScript, out instance)){
				instance = Graph.Clone<FlowScript>(flowScript);
				instances[flowScript] = instance;
			}

            instance.agent = graphAgent;
		    instance.blackboard = graphBlackboard;
			flowScript = instance;
		}

		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR
		
		protected override void OnNodeGUI(){
			
			GUILayout.Label(_flowScript.ToString());

			if (flowScript != null){

			} else {

				if (!Application.isPlaying && GUILayout.Button("CREATE NEW"))
					Node.CreateNested<FlowScript>(this);
			}
		}

		protected override void OnNodeInspectorGUI(){

			ShowBaseFSMInspectorGUI();
			EditorUtils.BBParameterField("FlowScript", _flowScript);

			if (flowScript != null){
				flowScript.name = this.name;
			}
		}

		#endif
	}
}