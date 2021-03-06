﻿using ParadoxNotion.Design;
using UnityEngine;

namespace FlowCanvas.Nodes{

	[Description("Perform a for loop")]
	[Category("Flow Controllers/Iterators")]
	[ContextDefinedInputs(typeof(int))]
	[ContextDefinedOutputs(typeof(int))]
	public class ForLoop : FlowControlNode {
		
		private int current;
		private bool broken;

		protected override void RegisterPorts(){
			var n = AddValueInput<int>("Loops");
			AddValueOutput<int>("Index", ()=> {return current;});
			var fCurrent = AddFlowOutput("Do");
			var fFinish = AddFlowOutput("Done");
			AddFlowInput("In", (f)=>
			{
				current = 0;
				broken = false;
				for (var i = 0; i < n.value; i++){
					if (broken){
						break;
					}
					current = i;
					fCurrent.Call(f);
				}
				fFinish.Call(f);
			});

			AddFlowInput("Break", (f)=>{ broken = true; });
		}		
	}
}