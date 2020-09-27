using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Utility")]
	[Description("Send a graph event to target list. Use along with the 'Check Event' Condition")]
	public class SendEventToTargetList : ActionTask<GraphOwner> {

		[RequiredField]
		public BBParameter<string> eventName;
		public BBParameter<float> delay;
        public BBParameter<List<GraphOwner>> targets;

        protected override string info{
			get{ return "Send Event [" + eventName + "]" + (delay.value > 0? " after " + delay + " sec." : "" ) + " to targets";}
		}

		protected override void OnUpdate(){
			if (elapsedTime > delay.value){
                List<GraphOwner> owners = targets.value;
                int count = owners.Count;
                for (int i = 0; i < count; ++i)
                {
                    owners[i].SendEvent( new EventData(eventName.value) );
                }
				EndAction();
			}
		}
	}
}