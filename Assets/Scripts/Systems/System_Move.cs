using UnityEngine;
using UnityEngine.EventSystems;
using NotImplementedException = System.NotImplementedException;

namespace RJD.System {
	public class System_Move : MonoBehaviour,IPointerEnterHandler, IPointerClickHandler {
		public GameObject character = null;
		public float speed = 50;
		
		private RectTransform rect = null;
		private GameObject moveTarget = null;
		Vector3 movePosition = Vector3.zero;

		private void Start () {
			movePosition = character.transform.position;
			rect = GetComponent <RectTransform> ();
		}

		private void Update () {
			if (character.transform.position != movePosition) {
				character.transform.position = Vector3.MoveTowards (character.transform.position, movePosition, Time.deltaTime * speed);
			}
		}

		public void OnPointerEnter (PointerEventData eventData) {
			if (eventData.pointerEnter.layer != 7) return;
			moveTarget = eventData.pointerEnter;
		}

		public void OnPointerClick (PointerEventData eventData) {
			if (!moveTarget) return;

			Vector2 _movePos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle (
				rect, Input.mousePosition, Camera.main,
				out _movePos);

			movePosition = rect.transform.TransformPoint(_movePos);
		}
	}
}
