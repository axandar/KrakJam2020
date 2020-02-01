using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	
	public class ConcreteSplasher : MonoBehaviour{

		[SerializeField] private SplashColliderCreator splashColliderCreator;
		[SerializeField] private int splattingTime;
		[SerializeField] private ParticleSystem particleSystem;
		
		[Button]
		public void SplashConcrete(){
			splashColliderCreator.gameObject.SetActive(true);
			particleSystem.Play();
			StartCoroutine(DisableSplashColliderAfterSeconds());
		}

		private IEnumerator DisableSplashColliderAfterSeconds(){
			yield return new WaitForSeconds(splattingTime);
			splashColliderCreator.gameObject.SetActive(false);
			particleSystem.Stop();
		}
	}
}