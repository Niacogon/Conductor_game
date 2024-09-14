using UnityEngine;
using UnityEngine.EventSystems;

namespace RJD.UI {
	public class UI_MovePosition : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IPointerMoveHandler {
		private RectTransform rect = null;
		private GameObject uiObject = null;

		private void Start () {
			rect = GetComponent <RectTransform> ();
		}

		public void OnPointerEnter (PointerEventData eventData) {
			if (eventData.pointerEnter.layer != 3) return;
			uiObject = eventData.pointerEnter;
		}

		public void OnPointerExit (PointerEventData eventData) {
			if (eventData.pointerEnter.layer != 3) return;
			uiObject = null;
		}
		
		public void OnPointerMove (PointerEventData eventData) {
			if (!eventData.eligibleForClick || !uiObject) return;

			Vector2 _movePos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle (
				rect, Input.mousePosition, Camera.main,
				out _movePos);

			Vector3 _mousePos = rect.transform.TransformPoint(_movePos);
			uiObject.transform.position = _mousePos;
		}
	}
}