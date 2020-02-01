using UnityEngine;


public class GenerateRoad : MonoBehaviour{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Transform roadsHolder;
    [SerializeField] private Transform startingTile;
    //[SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistanceToSpawnNextRoadTile;
    [SerializeField] private float timeToDestroy;
    
    private Vector3 _lastEndPointLocation;

    private void Awake(){
        _lastEndPointLocation = startingTile.Find("EndPoint").position;
        SpawnRoadTile();
    }

    // private void Update(){
    //     if (Vector3.Distance(playerTransform.position,_lastEndPointLocation) < minDistanceToSpawnNextRoadTile){
    //         SpawnRoadTile();
    //     }
    //
    // }

    private void SpawnRoadTile(){
        var lastRoadTileTransform = SpawnRoadTile(_lastEndPointLocation);
        _lastEndPointLocation = lastRoadTileTransform.Find("EndPoint").position;
    }

    private Transform SpawnRoadTile(Vector3 spawnLocation){
        var instantiatedObject = Instantiate(roadPrefab, spawnLocation, Quaternion.identity,roadsHolder);
		Destroy(instantiatedObject,timeToDestroy);
        return instantiatedObject.transform;
    }

}
