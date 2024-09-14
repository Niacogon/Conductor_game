using UnityEngine;

namespace RJD.UI {
	public class UI_SelectMission : MonoBehaviour {
		public UI_Dialog dialog = null;
		public Dialog [] startDialogs;

		public void OnSelectMission (int missionID) {
			dialog.currentDialog = startDialogs [missionID - 1];
			dialog.currentDialog.character.verification = Character.VerificationType.none;
			dialog.SelectAnswer (-1);
		}
	}
}
