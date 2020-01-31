using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{

	[RequireComponent(typeof(BoxCollider))]
	public class SplashColliderCreator : MonoBehaviour{
		private void Awake(){
			var localTransform = transform;
			var backwardTransform = localTransform.parent.forward * -1;
			localTransform.forward = backwardTransform;
			
			var boxCollider = GetComponent<BoxCollider>();
			boxCollider.isTrigger = true;
		}

		private void OnCollisionEnter(Collision other){
			other
		}
	}
}