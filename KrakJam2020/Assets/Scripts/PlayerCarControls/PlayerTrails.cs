using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrails : MonoBehaviour{
    [SerializeField] private List<TrailRenderer> trails;
    [SerializeField] private AudioSource audioSource;

    public void ActivateTrails(){
        audioSource.Play();
        foreach (var trail in trails){
            trail.emitting = true;
        }
    }
    
    public void DeactivateTrails(){
        foreach (var trail in trails){
            trail.emitting = false;
        }
        audioSource.Stop();
    }
}
