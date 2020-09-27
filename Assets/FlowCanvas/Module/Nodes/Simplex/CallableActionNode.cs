using System;
using System.Collections;
using System.Reflection;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	///Action Nodes do not return any value and can have up to 5 parameters. They need Flow execution.
	abstract public class CallableActionNode : SimplexNode {}
	

	abstract public class CallableActionNode<T1> : CallableActionNode{
		abstract public void Invoke(T1 a);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value); o.Call(f); });
		}		
	}

	abstract public class CallableActionNode<T1, T2> : CallableActionNode{
		abstract public void Invoke(T1 a, T2 b);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value, p2.value); o.Call(f); });
		}		
	}

	abstract public class CallableActionNode<T1, T2, T3> : CallableActionNode{
		abstract public void Invoke(T1 a, T2 b, T3 c);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value, p2.value, p3.value); o.Call(f); });
		}		
	}

	abstract public class CallableActionNode<T1, T2, T3, T4> : CallableActionNode{
		abstract public void Invoke(T1 a, T2 b, T3 c, T4 d);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value, p2.value, p3.value, p4.value); o.Call(f); });
		}		
	}

	abstract public class CallableActionNode<T1, T2, T3, T4, T5> : CallableActionNode{
		abstract public void Invoke(T1 a, T2 b, T3 c, T4 d, T5 e);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			var p5 = node.AddValueInput<T5>(parameters[4].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value, p2.value, p3.value, p4.value, p5.value); o.Call(f); });
		}		
	}

	abstract public class CallableActionNode<T1, T2, T3, T4, T5, T6> : CallableActionNode{
		abstract public void Invoke(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			var p5 = node.AddValueInput<T5>(parameters[4].Name.SplitCamelCase());
			var p6 = node.AddValueInput<T6>(parameters[5].Name.SplitCamelCase());
			node.AddFlowInput(" ", (Flow f)=> { Invoke(p1.value, p2.value, p3.value, p4.value, p5.value, p6.value); o.Call(f); });
		}		
	}
}