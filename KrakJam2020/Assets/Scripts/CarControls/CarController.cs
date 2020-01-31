using UnityEngine;

public class CarController : MonoBehaviour {
	[SerializeField] private float playerSpeed;
	[SerializeField] private float maxYOffset;
	[SerializeField] private float maxXOffset;

	private Vector2 _playerInput;
	
	private Rigidbody _rigidbody;
	private Transform _cameraTransform;
	
	private void Start() {
		_cameraTransform = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).transform;
		_rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	private void Update() {
		ReadPlayerInput();
	}

	private void ReadPlayerInput() {
		_playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	private void FixedUpdate() {
		ApplyPlayerInput();
	}

	private void ApplyPlayerInput() {
		_rigidbody.AddForce(_playerInput * (playerSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
	}
}
