using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnProps : MonoBehaviour
{
	[SerializeField] private List<GameObject> propsList;
	[Range(0,1)]
	[SerializeField] private float chanceToSpawnProp;
	[SerializeField] private float offsetX;
	[SerializeField] private float offsetY;

	private void Awake(){
		if (propsList.IsNullOrEmpty()){ return; }
		if (Random.value <= chanceToSpawnProp){
			SpawnRandomProp();
		}
	}

	private void SpawnRandomProp(){
		
		var propToSpawn = GetRandomProp();
		//var randomPosition = GetRandomPosition();
		var prop = Instantiate(propToSpawn, gameObject.transform.position, Quaternion.identity);
	}

	private GameObject GetRandomProp(){
		return propsList[Random.Range(0, propsList.Count)];
	}

	// private Vector3 GetRandomPosition(){
	// 	var position = transform.position;
	// 	var posX = position.x + Random.Range(-offsetX, offsetX);
	// 	var posY = position.y + Random.Range(-offsetY, offsetY);
	// 	var posZ = position.z;
	// 	return new Vector3(posX,posY,posZ);
	// }

	private void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(offsetX*2,offsetY*2));
	}
}
