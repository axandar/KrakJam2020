using System.Collections;
using TMPro;
using UnityEngine;

public class FloatingScoreSpawner : MonoBehaviour {
	[SerializeField] GameObject floatingScoreTextPrefab;
	[SerializeField] float floatingTextMoveUpSpeed;
	[SerializeField] float floatingTextYSpawnOffset;
	[SerializeField] float floatingPointsLingerTime;

	[SerializeField] Transform cameraTransform;

	public void SpawnFloatingPointsAmount(int pointAmount, Vector3 spawnPosition) {
		var spawnPosInternal =
			new Vector3(spawnPosition.x, spawnPosition.y + floatingTextYSpawnOffset, spawnPosition.z);
		var spawnedFloatingScoreObject = Instantiate(floatingScoreTextPrefab, spawnPosInternal,
			floatingScoreTextPrefab.transform.rotation);
		
		var spawnedFloatingScoreText = spawnedFloatingScoreObject.GetComponentInChildren<TextMeshProUGUI>();
		spawnedFloatingScoreText.text = pointAmount.ToString();
		spawnedFloatingScoreText.color = pointAmount > 0 ? Color.green : Color.red;
		StartCoroutine(FloatingTextCoroutine(spawnedFloatingScoreObject, floatingTextMoveUpSpeed,
			floatingPointsLingerTime));
	}

	private IEnumerator FloatingTextCoroutine(GameObject floatingText, float moveUpSpeed, float destroyTime) {
		var floatingTextTransform = floatingText.transform;
		var timer = 0f;
		while (timer < destroyTime) {
			floatingTextTransform.Translate(Vector3.up * (Time.deltaTime * moveUpSpeed));
			var toCameraVector = (floatingTextTransform.position - cameraTransform.position).normalized;
			floatingTextTransform.forward = toCameraVector;
			timer += Time.deltaTime;
			yield return null;
		}
		Destroy(floatingText);
	}
}