using System;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CarController : MonoBehaviour {
	public Action playerTurningEffectsStartedEvent;
	public Action playerTurningEffectsStoppedEvent;
	
	[SerializeField] float playerAccelerationSpeed;
	[SerializeField] float maxPlayerHorizontalVelocity;
	[SerializeField] float playerRotationMaxValue;
	
	float _playerRotationAngle;
	Vector2 _playerInput;

	Rigidbody _rigidbody;

	void Start() {
		_rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	void Update() {
		ReadPlayerInput();
	}

	void ReadPlayerInput() {
		_playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void FixedUpdate() {
		ApplyPlayerInputToRb();
		CalculateCarRotationAngle();
		ApplyCarRotationAngle();
		Debug.Log(_rigidbody.velocity);
	}

	void ApplyPlayerInputToRb() {
		_rigidbody.AddForce(_playerInput * (playerAccelerationSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
		ClampPlayerVelocity();
	}

	void ClampPlayerVelocity() {
		var playerHorizontalVelocity = _rigidbody.velocity.x;
		if (playerHorizontalVelocity > maxPlayerHorizontalVelocity) {
			_rigidbody.velocity = new Vector2(maxPlayerHorizontalVelocity, _rigidbody.velocity.y);
		}else if (playerHorizontalVelocity < -maxPlayerHorizontalVelocity) {
			_rigidbody.velocity = new Vector2(-maxPlayerHorizontalVelocity, _rigidbody.velocity.y);
		}
	}
	  
	void CalculateCarRotationAngle() {
		var playerHorizontalVelocity = _rigidbody.velocity.x;
		if (playerHorizontalVelocity > 0) {
			_playerRotationAngle = playerHorizontalVelocity
				.RemapFloatValueToRange(0, maxPlayerHorizontalVelocity,
					0, -playerRotationMaxValue);
		} else if (playerHorizontalVelocity < 0) {
			_playerRotationAngle = playerHorizontalVelocity
				.RemapFloatValueToRange(0, -maxPlayerHorizontalVelocity,
					0, playerRotationMaxValue);
		}
		
	}

	void ApplyCarRotationAngle() {
		var currentRbRotation = _rigidbody.rotation.eulerAngles;
		_rigidbody.rotation = Quaternion.Euler(currentRbRotation.x, currentRbRotation.y, _playerRotationAngle);
	}
}
