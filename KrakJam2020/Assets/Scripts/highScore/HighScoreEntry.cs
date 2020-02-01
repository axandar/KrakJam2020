using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace highScore{
	[Serializable]
	public class HighScoreEntry{
		[SerializeField] string playerName;
		[SerializeField] int score;
		[SerializeField] long millisecondsOnPlayStart;
		[SerializeField] long millisecondsOnPlayEnd;
		public HighScoreEntry(){}

		public string PlayerName{
			get => playerName;
			set => playerName = value;
		}

		public int Score{
			get => score;
			set => score = value;
		}

		public long MillisecondsOnPlayStart{
			get => millisecondsOnPlayStart;
			set => millisecondsOnPlayStart = value;
		}

		public long MillisecondsOnPlayEnd{
			get => millisecondsOnPlayEnd;
			set => millisecondsOnPlayEnd = value;
		}

		public int TimePlayedInSeconds(){
			var millisOfPlay = millisecondsOnPlayEnd - millisecondsOnPlayStart;
			return (int) (millisOfPlay / 1000);
		}
	}
}