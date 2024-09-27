using RJD.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using NotImplementedException = System.NotImplementedException;

namespace RJD.System {
	public class System_MoveTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
		[SerializeField, Tooltip ("Маска пересечения")]
		private LayerMask rayMask;
		private UI_Inventory_Slot currentSlot = null;
		
		private Transform moveObject = null;
		private Vector3 moveObject_StartPos = Vector3.zero;

		private void Update () {
			if (Input.GetMouseButtonDown (0)) {
				if (currentSlot && currentSlot.currentItem) {
					Debug.Log (currentSlot.currentItem.itemName);
					moveObject = currentSlot.currentItem.transform;
				} else Ray2WorldObject ();
			} else if (moveObject) {
				MoveObject ();
			}

			if (Input.GetMouseButtonUp (0) && moveObject) {
				if (currentSlot && moveObject.GetComponent <System_Item> ()) {
					currentSlot.currentItem = moveObject.GetComponent <System_Item> ();
					moveObject.gameObject.SetActive (false);
				} else if (moveObject) {
					moveObject.gameObject.SetActive (true);
				} 
				//else moveObject.position = moveObject_StartPos;
				
				moveObject = null;
			}
		}
		
		public void OnPointerEnter (PointerEventData eventData) {
			Debug.Log ("Курсор зашел на " + eventData.pointerEnter.name);
			
			if (eventData.pointerEnter.GetComponent <UI_Inventory_Slot> ()) {
				currentSlot = eventData.pointerEnter.GetComponent <UI_Inventory_Slot> ();
			}
		}
		
		public void OnPointerExit (PointerEventData eventData) {
			Debug.Log ("Курсор вышел из UI");

			if (currentSlot) {
				currentSlot = null;
			}
		}

		/// <summary>
		/// Бросок луча до мирового объекта
		/// </summary>
		void Ray2WorldObject () {
			RaycastHit _rayHit = new RaycastHit ();
			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (_ray, out _rayHit, 150, rayMask)) {
				moveObject = _rayHit.transform;
				moveObject_StartPos = moveObject.transform.position;
			}
		}

		/// <summary>
		/// Передвижение объекта
		/// </summary>
		void MoveObject () {
			Vector3 _newPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			_newPos.y = 25;

			moveObject.position = _newPos;
		}
	}
}
