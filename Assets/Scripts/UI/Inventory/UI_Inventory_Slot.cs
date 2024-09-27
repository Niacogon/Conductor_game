using UnityEngine;
using UnityEngine.UI;
using RJD.System;

namespace RJD.UI {
	public class UI_Inventory_Slot : MonoBehaviour {
		public System_Item currentItem = null;

		[Space, Header ("Настройки слота"), SerializeField, Tooltip ("Мконка слота")]
		private Image slotIcon = null; 

		private void Update () {
			if (!currentItem) {
				slotIcon.enabled = false;
				return;
			}

			slotIcon.enabled = true;
			slotIcon.sprite = currentItem.itemIcon;
		}
	}
}
