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
	[RequireComponent(typeof(ParticleSystem))]
	public class RoadObstacle : MonoBehaviour {
		[SerializeField] private int score;
		[SerializeField] private float particleEffectDuration;
		public float heightOffset;
		public HighScore highScore;
		public HealthPointsSystem healthPointsSystem;

		private AudioSource _audioSource;
		private ParticleSystem _particleSystem;
		
		
		private void Start(){
			_audioSource = GetComponent<AudioSource>();
			_particleSystem = GetComponent<ParticleSystem>();
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
			_particleSystem.Play();
			StartCoroutine(WaitForParticleSystemStop());
		}
		
		private IEnumerator WaitForParticleSystemStop(){
			yield return new WaitForSeconds(particleEffectDuration);
			_particleSystem.Stop();
		}
	}
}