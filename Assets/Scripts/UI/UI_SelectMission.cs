using System.Collections.Generic;
using UnityEngine;

namespace RJD.UI {
	public class UI_SelectMission : MonoBehaviour {
		public UI_Dialog dialog = null;
		public Dialog [] startDialogs;
		public RandomCharacterData randomData = null;

		[Header ("Пассажиры"), Tooltip("Число пассажиров\nX - минимальное, Y - максимальное")]
		public Vector2Int characterNumber = new Vector2Int (10, 25);
		public List <Character> characterList = new List <Character> ();

		public void OnSelectMission (int missionID) {
			dialog.currentDialog = startDialogs [missionID - 1];
			dialog.currentDialog.character.verification = Character.VerificationType.none;
			//Случайная установка персонажа
			if (dialog.currentDialog.character.randomData) SetCharacterRandomData (dialog.currentDialog.character);
			//Установка пассажиров
			int _characterCount = Random.Range (characterNumber.x, characterNumber.y);
			for (int _nc = 0; _nc < _characterCount; _nc++) {
				Character _newCharacter = new Character ();
				
				_newCharacter.name = "character_" + _nc;
				SetCharacterRandomData (_newCharacter);
				
				characterList.Add (_newCharacter);
				Debug.Log ("Новый пассажир " + _nc + " под именем: " + _newCharacter.characterName);
			}
			//Тестовый запуск диалога
			dialog.SelectAnswer (-1);
		}

		/// <summary>
		/// Установка случайных данных для персонажа
		/// </summary>
		/// <param name="curCharacter">
		/// Текущий персонаж
		/// </param>
		void SetCharacterRandomData (Character curCharacter) {
			curCharacter.pasportId = "";
			for (int _pi = 0; _pi < 12; _pi++) {
				if (_pi != 2 && _pi != 5) curCharacter.pasportId += Random.Range (0, 9).ToString ();
				else curCharacter.pasportId += " ";
			}

			curCharacter.gender = (Character.GenderType) Random.Range (0, 1);
			curCharacter.cityPasspor = randomData.GetRandomCity ();

			curCharacter.characterName = randomData.GetRandomName (curCharacter.gender);
			curCharacter.age = Random.Range (20, 90);
		}
	}
}
