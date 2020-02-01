using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCarCollisionsLogic : MonoBehaviour {
	public UnityEvent<Obstacle> obstacleCollidedEvent;
	
	[SerializeField] float obstacleTypeCollisionIgnoreTime;

	List<Obstacle.ObstacleType> _currentlyIgnoredObstacleTypes;

	void OnTriggerEnter(Collider other) {
		var obstacleScript = other.GetComponent<Obstacle>();
		if (obstacleScript == null) {return;}
		var collidedObstacleType = obstacleScript.obstacleType;
		if(_currentlyIgnoredObstacleTypes.Contains(collidedObstacleType)) { return; }
		
		obstacleCollidedEvent.Invoke(obstacleScript);
		obstacleScript.ObstacleCollidedWithPlayer();
		ReactToObstacleCollision(other, collidedObstacleType );
		StartCoroutine(TempIgnoreObstacleType(collidedObstacleType, obstacleTypeCollisionIgnoreTime));
	}

	void ReactToObstacleCollision(Collider other, Obstacle.ObstacleType obstacleType) {
		switch (obstacleType) {
			default:
				throw new ArgumentNullException(obstacleType.ToString(),"obstacleType not recognized!");
		}
		//TODO: add car behaviour
	}

	IEnumerator TempIgnoreObstacleType(Obstacle.ObstacleType ignoredObstacleType, float obstacleTypeIgnoreTime) {
		_currentlyIgnoredObstacleTypes.Add(ignoredObstacleType);
		yield return new WaitForSeconds(obstacleTypeIgnoreTime);
		_currentlyIgnoredObstacleTypes.Remove(ignoredObstacleType);
	}
}


