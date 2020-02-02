using System;
using highScore;
using Obstacle;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	[RequireComponent(typeof(Rigidbody), typeof(RoadObstacle))]
	public class SplashableByConcrete : MonoBehaviour{
		[SerializeField] bool isSplashed;
		[SerializeField] int scoreGainedBySplashing;
		[SerializeField] HighScore highScore;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Sprite filledHole;
		
		private RoadObstacle _roadObstacle;

		private void Start(){
			_roadObstacle = GetComponent<RoadObstacle>();
			highScore = _roadObstacle.highScore;
		}

		public void SplashByConcrete(){
			if(isSplashed){
				return;
			}
			
			isSplashed = true;
			spriteRenderer.sprite = filledHole;
			_roadObstacle.enabled = false;
			highScore.AddScore(scoreGainedBySplashing);
		}
	}
}