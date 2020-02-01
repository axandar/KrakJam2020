using UnityEngine;

public class RoadCar : MonoBehaviour {
	[SerializeField] float roadMovementSpeed;

	void Update() {
		transform.Translate(Vector3.right * roadMovementSpeed, Space.World);
	}
}
