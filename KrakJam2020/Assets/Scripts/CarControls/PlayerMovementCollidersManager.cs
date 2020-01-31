using UnityEngine;

public class PlayerMovementCollidersManager : MonoBehaviour {
    [SerializeField] Transform playerCollidersHolder;
    
    [SerializeField] GameObject verticalColliderPrefab;
    [SerializeField] GameObject horizontalColliderPrefab;

    [SerializeField] float verticalColliderXOffset;
    [SerializeField] float horizontalColliderYOffset;

    [SerializeField] float gizmosSpheresRadius;

    void Start(){
        SpawnColliders();
    }

    void SpawnColliders() {
        var position = transform.position;
        //spawn vertical colliders
        Instantiate(verticalColliderPrefab, new Vector2(verticalColliderXOffset, position.y),
            Quaternion.identity, playerCollidersHolder);
        Instantiate(verticalColliderPrefab, new Vector2(-verticalColliderXOffset, position.y),
            Quaternion.identity, playerCollidersHolder);
        
        //spawn horizontal colliders
        Instantiate(horizontalColliderPrefab, new Vector2(position.x, horizontalColliderYOffset),
            Quaternion.identity, playerCollidersHolder);
        Instantiate(horizontalColliderPrefab, new Vector2(position.x, -horizontalColliderYOffset),
            Quaternion.identity, playerCollidersHolder);
    }

    void OnDrawGizmos() {
        var position = transform.position;
        Gizmos.DrawWireSphere(new Vector2(verticalColliderXOffset, position.y),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(-verticalColliderXOffset, position.y),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(position.x, horizontalColliderYOffset),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(position.x, -horizontalColliderYOffset),gizmosSpheresRadius);
    }
}
