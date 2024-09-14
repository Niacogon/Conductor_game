using UnityEditor;
using UnityEngine;

namespace RJD.UI {
	public class UI_Menu : MonoBehaviour {
		public void Quit () {
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}