using System;
using UnityEngine;

namespace RJD {
	/// <summary>
	/// Класс персонажа
	/// </summary>
	[CreateAssetMenu (menuName = "RJD/Character", order = 1)]
	public class Character : ScriptableObject {
		public string characterName = "name";
		public GenderType gender = GenderType.M;
		public int age = 30;
		public string cityPasspor = "x";
		public string pasportId = "00 00 000000";
		public Sprite pasportAvatar;
		public Sprite photo;
		public VerificationType verification = VerificationType.none;

		/// <summary>
		/// Тип пола
		/// </summary>
		public enum GenderType {
			M, W
		}
		/// <summary>
		/// Тип проверки
		/// </summary>
		public enum VerificationType {
			none, yes, no
		}
	}
}
