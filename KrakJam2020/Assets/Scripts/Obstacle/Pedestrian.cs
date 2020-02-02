using System.Collections.Generic;
using UnityEngine;

namespace Obstacle{
	public class Pedestrian : RoadObstacle {
	
		[SerializeField] private List<GameObject> models;
	
		private void Awake(){
			LoadRandomModel();
		}

		private void LoadRandomModel(){
			var randomPedestrianModel = models[Random.Range(0, models.Count)];
			Instantiate(randomPedestrianModel, gameObject.transform);
		}
	    
	}
}
