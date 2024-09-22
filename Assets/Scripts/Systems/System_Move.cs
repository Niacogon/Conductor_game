using UnityEngine;
using UnityEngine.AI;

namespace RJD.System {
	public class System_Move : MonoBehaviour {
		public NavMeshAgent agent = null;
		
		Vector3 movePosition = Vector3.zero;

		private void Start () {
			movePosition = agent.transform.position;
		}

		public void Update () {
			if (Input.GetMouseButtonUp (0)) {
				movePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				movePosition.y = agent.transform.position.y;
				agent.SetDestination (movePosition);
			}
		}
	}
}
