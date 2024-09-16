using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RJD.UI {
	public class UI_Dialog : MonoBehaviour {
		public Dialog currentDialog = null;
		public GameObject gameMenu = null;
		
		[Space, Header ("Dialog")]
		public TMP_Text characterName = null;
		public TMP_Text dialogTxt = null;
		[FormerlySerializedAs ("dialogAnswers")]
		public Button [] dialogAnswersBtn = new Button[2];
		public TMP_Text [] dialogAnswersTxt = new TMP_Text[2];

		[Space, Header ("Passport")]
		public GameObject passport = null;
		public TMP_Text characterPasName = null;
		public TMP_Text characterPasGender = null;
		public TMP_Text characterPasAge = null;
		public TMP_Text characterPasCity = null;
		public TMP_Text characterPasID = null;
		public Image characterPasAvatar = null;
		
		[Space, Header ("Phone")]
		public GameObject phone = null;
		public TMP_Text phoneCity = null;
		public TMP_Text phoneName = null;
		public TMP_Text phoneID = null;

		private void Start () {
			SelectAnswer (-1);
		}

		public void SelectAnswer (int indexAnswer) {
			if (indexAnswer != -1) currentDialog = currentDialog.answersText [indexAnswer].nextDialog;
			//Тестовый конец игры
			if (currentDialog == null) {
				gameObject.SetActive (false);
				passport.SetActive (false);
				gameMenu.SetActive (true);
				
				return;
			}
			//Установка диалога
			characterName.SetText (currentDialog.character.characterName);
			dialogTxt.SetText (currentDialog.dialogText);
			for (int _da = 0; _da < dialogAnswersBtn.Length; _da++) {
				if (currentDialog.answersText [_da].answerText != "") {
					dialogAnswersBtn [_da].gameObject.SetActive (true);
					dialogAnswersTxt [_da].SetText (currentDialog.answersText [_da].answerText);
				} else dialogAnswersBtn [_da].gameObject.SetActive (false);
			}

			if (currentDialog.character.verification == Character.VerificationType.none) {
				//Установка папорта
				passport.SetActive (true);

				characterPasName.SetText (currentDialog.character.characterName);
				string _genderName = currentDialog.character.gender == Character.GenderType.M ? "М" : "Ж";
				characterPasGender.SetText (_genderName);
				characterPasAge.SetText (currentDialog.character.age + " лет");
				characterPasCity.SetText (currentDialog.character.cityPasspor);
				characterPasID.SetText (currentDialog.character.pasportId);
				characterPasAvatar.sprite = currentDialog.character.pasportAvatar;
				//Установка телефона
				phone.SetActive (true);

				phoneName.SetText (currentDialog.character.characterName);
				phoneID.SetText (currentDialog.character.pasportId);
			}
		}

		/// <summary>
		/// Установка проверки (тестовое расположение)
		/// </summary>
		/// <param name="type">
		/// Тип проверки, как номер от 1 до 2
		/// </param>
		public void SetVerification (int type) {
			currentDialog.character.verification = (Character.VerificationType) type;
			
			passport.SetActive (false);
			phone.SetActive (false);
		}
	}
}
