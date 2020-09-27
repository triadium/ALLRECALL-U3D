using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	[Category("Functions/Navigation")]
	[Description("Moves a NavMeshAgent object with pathfinding to target destination")]
	public class MoveTo : LatentActionNode<UnityEngine.AI.NavMeshAgent, Vector3, float, float>{
		public override IEnumerator Invoke(UnityEngine.AI.NavMeshAgent agent, Vector3 destination, float speed, float stoppingDistance){
			agent.speed = speed;
			agent.stoppingDistance = stoppingDistance;
			if (agent.speed > 0){
				agent.SetDestination(destination);
			} else {
				agent.Warp(destination);
			}
			while (agent.pathPending || agent.remainingDistance > stoppingDistance){
				yield return null;
			}
		}
	}
}