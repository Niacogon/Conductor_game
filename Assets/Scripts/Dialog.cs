using System;
using UnityEngine;

namespace RJD {
	/// <summary>
	/// Класс диалога
	/// </summary>
	[CreateAssetMenu (menuName = "RJD/Dialog", order = 2)]
	public class Dialog : ScriptableObject {
		public Character character = null;
		[Multiline (10)]
		public string dialogText = "";
		public Dialog_Answers [] answersText;
	}

	/// <summary>
	/// Ответ на диалог
	/// </summary>
	[Serializable]
	public class Dialog_Answers {
		public string answerText = "";
		public Dialog nextDialog;
	}
}