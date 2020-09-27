using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace FlowCanvas.Nodes{

	[Name("UI Slider")]
	[Category("Events/Input")]
	[Description("Called when the target UI Slider value is changed")]
	public class UISliderEvent : EventNode<Slider> {

		private FlowOutput _o;
        private float _v;

		public override void OnGraphStarted(){
            _v = 0;
            if (!target.isNull)
            {
                _v = target.value.value;
                target.value.onValueChanged.AddListener(OnValueChanged);
            }
            //else { noop }
		}

		public override void OnGraphStoped(){
			if (!target.isNull)
				target.value.onValueChanged.RemoveListener(OnValueChanged);
		}

		protected override void RegisterPorts(){
			_o = AddFlowOutput("Value changed");
            AddValueOutput<float>("Value", () => { return _v; }, "v");
        }

		void OnValueChanged(float v){
            _v = v;
			_o.Call(new Flow(1));
		}
	}
}