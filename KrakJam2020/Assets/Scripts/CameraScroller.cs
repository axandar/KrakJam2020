using UnityEngine;

public class CameraScroller : MonoBehaviour {
	[SerializeField] float scrollSpeed;

	void Update() {
		transform.Translate(transform.up * scrollSpeed);
	}
}
