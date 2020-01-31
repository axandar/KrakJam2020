using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace highScore{
	[Serializable]
	public class HighScoreEntry{
		[SerializeField]
		private string playerName;
		[SerializeField]
		private int score;
		[SerializeField]
		private int millisecondsOnPlayStart;
		[SerializeField]
		private int millisecondsOnPlayEnd;
		public HighScoreEntry(){}

		public string PlayerName{
			get => playerName;
			set => playerName = value;
		}

		public int Score{
			get => score;
			set => score = value;
		}

		public int MillisecondsOnPlayStart{
			get => millisecondsOnPlayStart;
			set => millisecondsOnPlayStart = value;
		}

		public int MillisecondsOnPlayEnd{
			get => millisecondsOnPlayEnd;
			set => millisecondsOnPlayEnd = value;
		}

		public int TimePlayedInSeconds(){
			var millisOfPlay = millisecondsOnPlayEnd - millisecondsOnPlayStart;
			return millisOfPlay / 1000;
		}
	}
}