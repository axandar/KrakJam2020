using UnityEngine;

public class PlayerMovementCollidersManager : MonoBehaviour {
    [SerializeField] Transform playerCollidersHolder;
    
    [SerializeField] GameObject verticalColliderPrefab;
    [SerializeField] GameObject horizontalColliderPrefab;

    [SerializeField] float verticalColliderZOffset;
    [SerializeField] float horizontalColliderYOffset;

    [SerializeField] float gizmosSpheresRadius;

    void Start(){
        SpawnColliders();
    }

    void SpawnColliders() {
        var position = transform.position;
        //spawn vertical colliders
        Instantiate(verticalColliderPrefab, new Vector3(0f, position.y, verticalColliderZOffset),
            Quaternion.identity, playerCollidersHolder);
        Instantiate(verticalColliderPrefab, new Vector3(0f, position.y, -verticalColliderZOffset),
            Quaternion.identity, playerCollidersHolder);
        
        //spawn horizontal colliders
        Instantiate(horizontalColliderPrefab, new Vector3(0f, horizontalColliderYOffset, position.z),
            horizontalColliderPrefab.transform.rotation, playerCollidersHolder);
        Instantiate(horizontalColliderPrefab, new Vector3(0f, -horizontalColliderYOffset, position.z),
            horizontalColliderPrefab.transform.rotation, playerCollidersHolder);
    }

    void OnDrawGizmos() {
        var position = transform.position;
        Gizmos.DrawWireSphere(new Vector3(0f, position.y, verticalColliderZOffset),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(0f, position.y, -verticalColliderZOffset), gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(0f, position.y + horizontalColliderYOffset, position.z),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(0f, position.y + -horizontalColliderYOffset, position.z),gizmosSpheresRadius);
    }
}
