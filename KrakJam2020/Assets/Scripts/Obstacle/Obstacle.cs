using UnityEngine;

public class Obstacle : MonoBehaviour {
	public int hpEffect;
	public int score;
	public ObstacleType obstacleType;
	
	[SerializeField] AudioClip collisionSound;
	[SerializeField] GameObject collisionParticleEffect;
	[SerializeField] float collisionParticleEffectLifetime;

	public void ObstacleCollidedWithPlayer() {
		var transformPosition = transform.position;
		AudioSource.PlayClipAtPoint(collisionSound, transformPosition);
		var spawnedCollisionParticleEffect = Instantiate(collisionParticleEffect, transformPosition,
			Quaternion.identity);
		Destroy(spawnedCollisionParticleEffect, collisionParticleEffectLifetime);
	}
	
	public enum ObstacleType {
		Obstacle,
		Hole,
		Granny
	}
}