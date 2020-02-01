using System.Collections.Generic;
using healthPointSystem;
using highScore;
using Obstacle;
using Sirenix.Utilities;
using UnityEngine;

namespace EndlessMapGeneration{
	public class RoadChunkHolder : MonoBehaviour{
		[SerializeField] private HighScore _highScore;
		[SerializeField] private HealthPointsSystem _healthPointsSystem;
		[SerializeField] private List<RoadObstacle> roadObstaclesOnLeft;
		[SerializeField] private List<RoadObstacle> roadObstaclesOnRight;
		[SerializeField] private List<GameObject> housesOnLeft;
		[SerializeField] private List<GameObject> housesOnRight;

		[SerializeField] private PropSpawner leftRoadChunk;
		[SerializeField] private PropSpawner rightRoadChunk;
		[SerializeField] private HouseSpawner leftHouseChunk;
		[SerializeField] private HouseSpawner rightHouseChunk;
		
		[Range(0, 1)] [SerializeField] float chanceToSpawnProp;

		public void SpawnObjectsOnChunk(){
			SpawnOnSpawner(leftRoadChunk, roadObstaclesOnLeft);
			SpawnOnSpawner(rightRoadChunk, roadObstaclesOnRight);
			SpawnOnSpawner(leftHouseChunk, housesOnLeft);
			SpawnOnSpawner(rightHouseChunk, housesOnRight);
		}

		private void SpawnOnSpawner(PropSpawner propSpawner, List<RoadObstacle> propList){
			if(propList.IsNullOrEmpty()){
				return;
			}
			propSpawner.SpawnRandomProp(propList, _highScore, _healthPointsSystem, chanceToSpawnProp);
		}

		private void SpawnOnSpawner(HouseSpawner houseSpawner, List<GameObject> propList){
			if(propList.IsNullOrEmpty()){
				return;
			}
			
			houseSpawner.SpawnRandomHouse(propList);
		}
		

		public HighScore HighScore{
			set => _highScore = value;
		}
		public HealthPointsSystem HealthPointsSystem{
			set => _healthPointsSystem = value;
		}
	}
}