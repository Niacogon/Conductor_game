using UnityEngine;

namespace RJD.UI {
	public class UI_MenuSelect : MonoBehaviour {
		public GameObject oldMenu = null;
		public GameObject newMenu = null;

		public void OnChangeMenu () {
			oldMenu.SetActive (false);
			newMenu.SetActive (true);
		}
	}
}
