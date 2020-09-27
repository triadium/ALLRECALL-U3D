using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace FlowCanvas.Nodes{

	[Name("UI Toggle")]
	[Category("Events/Input")]
	[Description("Called when the target UI Toggle value is changed")]
    public class UIToggleEvent : EventNode<UnityEngine.UI.Toggle>
    {
        private FlowOutput _o;
        private bool _v;

        public override void OnGraphStarted()
        {
            _v = false;
            if (!target.isNull)
            {
                _v = target.value.isOn;
                target.value.onValueChanged.AddListener(OnValueChanged);
            }
            //else { noop }
        }

        public override void OnGraphStoped()
        {
            if (!target.isNull)
                target.value.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void RegisterPorts()
        {
            _o = AddFlowOutput("Value changed");
            AddValueOutput<bool>("Value", () => { return _v; }, "v");
        }

        void OnValueChanged(bool v)
        {
            if (v != _v)
            {
                _v = v;
                _o.Call(new Flow(1));
            }
            //else { noop }
        }
    }
}