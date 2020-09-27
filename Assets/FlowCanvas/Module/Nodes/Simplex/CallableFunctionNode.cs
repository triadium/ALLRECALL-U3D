using System;
using System.Collections;
using System.Reflection;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	///Like PureFunctionNode but require Flow execution.
	abstract public class CallableFunctionNode : SimplexNode {}


	abstract public class CallableFunctionNode<TResult> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke();
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1, T2> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a, T2 b);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value, p2.value); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1, T2, T3> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a, T2 b, T3 c);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value, p2.value, p3.value); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1, T2, T3, T4> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a, T2 b, T3 c, T4 d);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value, p2.value, p3.value, p4.value); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1, T2, T3, T4, T5> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			var p5 = node.AddValueInput<T5>(parameters[4].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value, p2.value, p3.value, p4.value, p5.value); o.Call(f); });
		}
	}

	abstract public class CallableFunctionNode<TResult, T1, T2, T3, T4, T5, T6> : CallableFunctionNode {
		private TResult result;
		abstract public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f);
		sealed protected override void OnRegisterPorts(FlowNode node){
			var o = node.AddFlowOutput(" ");
			var p1 = node.AddValueInput<T1>(parameters[0].Name.SplitCamelCase());
			var p2 = node.AddValueInput<T2>(parameters[1].Name.SplitCamelCase());
			var p3 = node.AddValueInput<T3>(parameters[2].Name.SplitCamelCase());
			var p4 = node.AddValueInput<T4>(parameters[3].Name.SplitCamelCase());
			var p5 = node.AddValueInput<T5>(parameters[4].Name.SplitCamelCase());
			var p6 = node.AddValueInput<T6>(parameters[5].Name.SplitCamelCase());
			node.AddValueOutput<TResult>("Value", ()=> {return result;});
			node.AddFlowInput(" ", (f)=> { result = Invoke(p1.value, p2.value, p3.value, p4.value, p5.value, p6.value); o.Call(f); });
		}
	}
}