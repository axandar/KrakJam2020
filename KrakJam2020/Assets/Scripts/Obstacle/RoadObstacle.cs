using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using healthPointSystem;
using highScore;
using UnityEngine;

namespace Obstacle{
	[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), 
		typeof(AudioSource))]
	public class RoadObstacle : MonoBehaviour {
		[SerializeField] private int score;
		[SerializeField] private float particleEffectDuration;
		[SerializeField] private ParticleSystem particleSystem;
		public float heightOffset;
		public HighScore highScore;
		public HealthPointsSystem healthPointsSystem;

		private AudioSource _audioSource;

		private void Start(){
			_audioSource = GetComponent<AudioSource>();
		}

		private void OnTriggerEnter(Collider other){
			if(!other.gameObject.CompareTag(Tags.PLAYER)){
				return;
			}
			
			var playerCollisionHandler = other.gameObject.GetComponent <PlayerCollisionHandler>();
			playerCollisionHandler.CrashedIntoObstacle();
			
			highScore.AddScore(score);
			healthPointsSystem.DecreaseHealth();
			_audioSource.Play();

			if(particleSystem != null){
				var localParticleSystem = Instantiate(particleSystem, transform);
				localParticleSystem.Play();
				StartCoroutine(WaitForParticleSystemStop(localParticleSystem));
			}
		}
		
		private IEnumerator WaitForParticleSystemStop(ParticleSystem localParticleSystem){
			yield return new WaitForSeconds(particleEffectDuration);
			localParticleSystem.Stop();
		}
	}
}