using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{

	[RequireComponent(typeof(BoxCollider))]
	public class SplashColliderCreator : MonoBehaviour{
		private void Awake(){
			var localTransform = transform;
			var backwardTransform = localTransform.parent.forward * -1;
			localTransform.position = backwardTransform;
			
			var boxCollider = GetComponent<BoxCollider>();
			boxCollider.isTrigger = true;
			gameObject.SetActive(false);
		}

		private void OnTriggerEnter(Collider other){
			var isSplashable = other.gameObject.CompareTag(Tags.CAN_BE_SPLASHED_BY_CONCRETE);
			if(isSplashable){
				var splashableByConcrete = other.gameObject.GetComponent<SplashableByConcrete>();
				splashableByConcrete.SplashByConcrete();
				Debug.Log("Splashed Game Object!");
			}
		}
	}
}