using UnityEngine;

public class PlayerMovementCollidersManager : MonoBehaviour {
    [SerializeField] private Transform playerCollidersHolder;
    
    [SerializeField] private GameObject verticalColliderPrefab;
    [SerializeField] private GameObject horizontalColliderPrefab;

    [SerializeField] private float verticalColliderXOffset;
    [SerializeField] private float horizontalColliderYOffset;

    [SerializeField] private float gizmosSpheresRadius;

    private void Start(){
        SpawnColliders();
    }

    private void SpawnColliders() {
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

    private void OnDrawGizmos() {
        var position = transform.position;
        Gizmos.DrawWireSphere(new Vector2(verticalColliderXOffset, position.y),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(-verticalColliderXOffset, position.y),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(position.x, horizontalColliderYOffset),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector2(position.x, -horizontalColliderYOffset),gizmosSpheresRadius);
    }
}
