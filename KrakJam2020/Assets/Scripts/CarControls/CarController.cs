using UnityEngine;

public class CarController : MonoBehaviour {
	[SerializeField] float playerSpeed;
	[SerializeField] float maxYOffset;
	[SerializeField] float maxXOffset;

	Vector2 _playerInput;

	Rigidbody _rigidbody;
	Transform _cameraTransform;

	void Start() {
		_cameraTransform = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).transform;
		_rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	void Update() {
		ReadPlayerInput();
	}

	void ReadPlayerInput() {
		_playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void FixedUpdate() {
		ApplyPlayerInput();
	}

	void ApplyPlayerInput() {
		_rigidbody.AddForce(_playerInput * (playerSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
	}
}
