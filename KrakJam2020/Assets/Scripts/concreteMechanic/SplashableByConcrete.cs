using System;
using highScore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	[RequireComponent(typeof(Rigidbody))]
	public class SplashableByConcrete:MonoBehaviour{
		[SerializeField] private bool isSplashed;
		[SerializeField] private int scoreGainedBySplashing;
		[SerializeField] private HighScore highScore;

		public void SplashByConcrete(){
			if(isSplashed){
				return;
			}
			
			isSplashed = true;
			highScore.AddScore(scoreGainedBySplashing);
		}
	}
}