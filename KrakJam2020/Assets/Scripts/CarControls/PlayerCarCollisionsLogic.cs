using System;
using System.Collections;
using System.Collections.Generic;
using highScore;
using UnityEngine;

public class PlayerCarCollisionsLogic : MonoBehaviour {

	[SerializeField] CollisionTypeSettings[] collisionTypes;
	[SerializeField] float sameObjectCollisionIgnoreTime;
	
	private List<string> _currentlyIgnoredTagsList = new List<string>();
	HighScore _highScoreManager;

	void Start() {
		_highScoreManager = GameObject.FindWithTag(Tags.HIGH_SCORE).GetComponent<HighScore>();
	}

	void OnTriggerEnter(Collider other) {
		foreach (var collisionType in collisionTypes) {
			var otherTag = other.gameObject.tag;
			if (otherTag.Equals(collisionType.collidedGameObjectTag) &&
			    !_currentlyIgnoredTagsList.Contains(otherTag)) {
				ReactToCollision(other, collisionType);
				return;
			}
		}
	}

	void ReactToCollision(Collider other, CollisionTypeSettings collisionTypeSettings) {
		_highScoreManager.AddScore(collisionTypeSettings.collisionPoints);
		AudioSource.PlayClipAtPoint(collisionTypeSettings.collisionSound, transform.position);
		var collisionParticleEffect = Instantiate(collisionTypeSettings.collisionParticleEffect,
			other.transform.position, Quaternion.identity);
		Destroy(collisionParticleEffect, collisionTypeSettings.collisionParticleEffectDurationTime);
		//TODO: add car behaviour
		//TODO: updateHP
		
		StartCoroutine(LockTagFromInvokingCollisionEffects(collisionTypeSettings.collidedGameObjectTag,
			sameObjectCollisionIgnoreTime));
	}
	
	IEnumerator LockTagFromInvokingCollisionEffects(string ignoredTag, float lockTime) {
		_currentlyIgnoredTagsList.Add(ignoredTag);
		yield return new WaitForSeconds(lockTime);
		_currentlyIgnoredTagsList.Remove(ignoredTag);
	}
	
	[Serializable]
	private class CollisionTypeSettings {
		[SerializeField] public string collidedGameObjectTag;
		[SerializeField] public int collisionHpEffect;
		[SerializeField] public int collisionPoints;
		[SerializeField] public AudioClip collisionSound;
		[SerializeField] public GameObject collisionParticleEffect;
		[SerializeField] public float collisionParticleEffectDurationTime;
	}
}


