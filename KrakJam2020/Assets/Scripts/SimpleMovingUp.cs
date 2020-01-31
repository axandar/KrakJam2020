using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingUp : MonoBehaviour{
    [SerializeField] private float speed;
    private void Update(){
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }
    }
}
