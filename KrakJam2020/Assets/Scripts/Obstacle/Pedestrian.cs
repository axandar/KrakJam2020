using System.Collections;
using System.Collections.Generic;
using Obstacle;
using UnityEngine;

public class Pedestrian : RoadObstacle {
	
	[SerializeField] private List<GameObject> victimModels;
	
	private void Awake(){
		LoadRandomVictimModel();
	}

	private void LoadRandomVictimModel(){
		var randomCarModel = victimModels[Random.Range(0, victimModels.Count)];
		var instantiatedCarModel = Instantiate(randomCarModel, gameObject.transform);
	}
	    
}
