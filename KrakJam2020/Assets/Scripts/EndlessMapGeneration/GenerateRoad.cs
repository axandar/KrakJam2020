using UnityEngine;


public class GenerateRoad : MonoBehaviour{
    [SerializeField] GameObject roadPrefab;
    [SerializeField] Transform roadsHolder;
    [SerializeField] Transform startingTile;
    [SerializeField] Transform playerTransform;
    [SerializeField] float minDistanceToSpawnNextRoadTile;
    [SerializeField] float timeToDestroy;

    Vector3 _lastEndPointLocation;

    void Awake(){
        _lastEndPointLocation = startingTile.Find("EndPoint").position;
        SpawnRoadTile();
        SpawnRoadTile();
        SpawnRoadTile();
        
    }

    void Update(){
        if (Vector3.Distance(playerTransform.position,_lastEndPointLocation) < minDistanceToSpawnNextRoadTile){
            SpawnRoadTile();
        }
    
    }

    void SpawnRoadTile(){
        var lastRoadTileTransform = SpawnRoadTile(_lastEndPointLocation);
        _lastEndPointLocation = lastRoadTileTransform.Find("EndPoint").position;
    }

    Transform SpawnRoadTile(Vector3 spawnLocation){
        var instantiatedObject = Instantiate(roadPrefab, spawnLocation, Quaternion.identity,roadsHolder);
		Destroy(instantiatedObject,timeToDestroy);
        return instantiatedObject.transform;
    }

}
