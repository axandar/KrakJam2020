using Obstacle;
using UnityEngine;

public class RoadCar : RoadObstacle {
	[SerializeField] float roadMovementSpeed;

	void Update() {
		transform.Translate(Vector3.left * (roadMovementSpeed * Time.deltaTime), Space.World);
	}
}
