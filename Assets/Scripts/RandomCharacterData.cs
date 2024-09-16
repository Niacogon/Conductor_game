using UnityEngine;
using Random = UnityEngine.Random;

namespace RJD {
	/// <summary>
	/// Класс случайных данных персонажа
	/// </summary>
	[CreateAssetMenu (menuName = "RJD/Random Character Data", order = 3)]
	public class RandomCharacterData : ScriptableObject {
		public string [] cityList = new string [3];

		[Header ("Мужские имена")]
		public string [] fristNamesMan = new string [3];
		public string [] secondNamesMan = new string [3];
		
		[Header ("Женские имена")]
		public string [] fristNamesWoman = new string [3];
		public string [] secondNamesWoman = new string [3];

		/// <summary>
		/// Запрос случайного города
		/// </summary>
		/// <returns></returns>
		public string GetRandomCity () {
			return cityList [Random.Range (0, cityList.Length)];
		}
		
		/// <summary>
		/// Получение случйного имени
		/// </summary>
		/// <returns></returns>
		public string GetRandomName (Character.GenderType gender) {
			string _returnName = "";
			if (gender == Character.GenderType.M)
				_returnName = secondNamesMan [Random.Range (0, secondNamesMan.Length)] + " " + fristNamesMan [Random.Range (0, fristNamesMan.Length)];
			else 
				_returnName = secondNamesWoman [Random.Range (0, secondNamesWoman.Length)] + " " + fristNamesWoman [Random.Range (0, fristNamesWoman.Length)];
			
			return _returnName;
		}
	}
}
