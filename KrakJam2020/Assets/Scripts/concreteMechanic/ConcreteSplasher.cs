using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	
	[RequireComponent(typeof(AudioSource))]
	public class ConcreteSplasher : MonoBehaviour{

		[SerializeField] private SplashColliderCreator splashColliderCreator;
		[SerializeField] private int splattingTime;
		[SerializeField] private ParticleSystem particleSystem;
		
		private AudioSource _audioSource;

		private void Start(){
			_audioSource = GetComponent<AudioSource>();
		}

		[Button]
		public void SplashConcrete(){
			InitiateSplash();
			StartCoroutine(DisableSplashAfterSeconds());
		}

		private void InitiateSplash(){
			splashColliderCreator.gameObject.SetActive(true);
			particleSystem.Play();
			_audioSource.Play();
		}

		private IEnumerator DisableSplashAfterSeconds(){
			yield return new WaitForSeconds(splattingTime);
			splashColliderCreator.gameObject.SetActive(false);
			particleSystem.Stop();
			_audioSource.Stop();
		}
	}
}