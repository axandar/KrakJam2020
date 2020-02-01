using System;
using highScore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	[RequireComponent(typeof(Rigidbody))]
	public class SplashableByConcrete:MonoBehaviour{
		[SerializeField] bool isSplashed;
		[SerializeField] int scoreGainedBySplashing;
		[SerializeField] HighScore highScore;

		public void SplashByConcrete(){
			if(isSplashed){
				return;
			}
			
			isSplashed = true;
			highScore.AddScore(scoreGainedBySplashing);
		}
	}
}