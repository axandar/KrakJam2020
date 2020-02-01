using System;
using UnityEngine;

public class CarController : MonoBehaviour {
	public Action playerTurningEffectsStartedEvent;
	public Action playerTurningEffectsStoppedEvent;
	
	[SerializeField] float playerMoveSpeed;
	[SerializeField] float playerRotationChangeSpeed;
	[SerializeField] float playerRotationMaxValue;
	
	float _playerRotationAngle;

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
		UpdateCarRotationAngle();
		ApplyCarRotationAngle();
		Debug.log(_rigi);
	}

	void ApplyPlayerInput() {
		_rigidbody.AddForce(_playerInput * (playerMoveSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
	}
	
	void UpdateCarRotationAngle(){
		if (_playerInput.x > 0) {
			_playerRotationAngle -= Time.fixedDeltaTime * playerRotationChangeSpeed * 3;
		}else if (_playerInput.x < 0) {
			_playerRotationAngle += Time.fixedDeltaTime * playerRotationChangeSpeed * 3;
		} else {
			_playerRotationAngle = Mathf.MoveTowards(_playerRotationAngle, 0f,
			 Time.fixedDeltaTime * playerRotationChangeSpeed);
		}
		ClampCarRotationAngle();
	}
	
	void ClampCarRotationAngle() {
		if (_playerRotationAngle > playerRotationMaxValue) {
			_playerRotationAngle = playerRotationMaxValue;
		} else if (_playerRotationAngle < -playerRotationMaxValue) {
			_playerRotationAngle = -playerRotationMaxValue;
		}
	}

	void ApplyCarRotationAngle() {
		var currentRbRotation = _rigidbody.rotation.eulerAngles;
		_rigidbody.rotation = Quaternion.Euler(currentRbRotation.x, currentRbRotation.y, _playerRotationAngle);
	}
}
