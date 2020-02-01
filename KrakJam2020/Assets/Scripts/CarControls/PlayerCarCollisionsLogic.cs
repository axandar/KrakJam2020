using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCarCollisionsLogic : MonoBehaviour {
	public UnityEvent<Obstacle> obstacleCollidedEvent;
	
	[SerializeField] float obstacleCollisionCooldownTime;
	
	bool _isObstacleCollisionsOnCooldown;

	void OnTriggerEnter(Collider other) {
		var obstacleScript = other.GetComponent<Obstacle>();
		if (obstacleScript != null && !_isObstacleCollisionsOnCooldown) {
			obstacleCollidedEvent.Invoke(obstacleScript);
			obstacleScript.ObstacleCollidedWithPlayer();
			ReactToObtacleCollision(other, obstacleScript.obstacleType);
		}
	}

	void ReactToObtacleCollision(Collider other, Obstacle.ObstacleType obstacleType) {
		switch (obstacleType) {
			default:
				throw new ArgumentNullException(obstacleType.ToString(),"obstacleType not recognized!");
		}
		//TODO: add car behaviour
	}

	IEnumerator ObstacleCollisionsCooldown() {
		_isObstacleCollisionsOnCooldown = true;
		yield return new WaitForSeconds(obstacleCollisionCooldownTime);
		_isObstacleCollisionsOnCooldown = false;
	}
}


