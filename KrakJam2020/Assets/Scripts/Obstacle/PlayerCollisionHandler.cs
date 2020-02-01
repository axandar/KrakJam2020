using System;
using UnityEngine;

namespace Obstacle{
	public class PlayerCollisionHandler : MonoBehaviour {
		[SerializeField] private float shakeDurationEffect;
		
		private ObjectShakerScript _objectShakerScript;

		private void Start(){
			_objectShakerScript = GameObject.FindGameObjectWithTag(Tags.CAMERA_TO_SHAKE)
				.GetComponent<ObjectShakerScript>();
		}

		public void CrashedIntoObstacle(){
			//todo add force
			_objectShakerScript.Shake();
			Debug.Log("Can add force");
		}
	}
}


