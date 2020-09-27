using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;

namespace FlowCanvas{

	///FlowScripts are assigned or bound to FlowScriptControllers
	[System.Serializable]
	public class FlowScript : FlowGraph {


		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

		[UnityEditor.MenuItem("Window/NodeCanvas/Create/Graph/Flow Script")]
		public static void Editor_CreateGraph(){
			var newFS = EditorUtils.CreateAsset<FlowScript>(true);
			UnityEditor.Selection.activeObject = newFS;
		}

		[UnityEditor.MenuItem("Assets/Create/NodeCanvas/Flow Script")]
		public static void Editor_CreateGraphAsset(){
			var path = EditorUtils.GetAssetUniquePath("FlowScript.asset");
			var newGraph = EditorUtils.CreateAsset<FlowScript>(path);
			UnityEditor.Selection.activeObject = newGraph;
		}		

		#endif
	}
}
