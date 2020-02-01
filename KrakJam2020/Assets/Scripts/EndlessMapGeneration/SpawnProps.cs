using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnProps : MonoBehaviour
{
	[SerializeField] List<GameObject> propsList;
	[Range(0,1)]
	[SerializeField]
	float chanceToSpawnProp;
	[SerializeField] float offsetX;
	[SerializeField] float offsetZ;

	[SerializeField] float obstaclesOffsetY = 0.5f;

	void Awake(){
		if (propsList.IsNullOrEmpty()){ return; }
		if (Random.value <= chanceToSpawnProp){
			SpawnRandomProp();
		}
	}

	void SpawnRandomProp(){
		
		var propToSpawn = GetRandomProp();
		var randomPosition = GetRandomPosition();
		var prop = Instantiate(propToSpawn, randomPosition, propToSpawn.transform.rotation);
		Destroy(prop, 10f);
		
	}

	GameObject GetRandomProp(){
		return propsList[Random.Range(0, propsList.Count)];
	}

	Vector3 GetRandomPosition(){
		var position = transform.position;
		var posX = position.x + Random.Range(-offsetX, offsetX);
		var posY = position.y + obstaclesOffsetY;
		var posZ = position.z + Random.Range(-offsetZ, offsetZ);
		return new Vector3(posX,posY,posZ);
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(offsetX*2,0,offsetZ*2));
	}
}
