using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlocks : MonoBehaviour{
    [SerializeField] private List<Sprite> blocksSprites;

    private void Awake(){
        var randomSprite = GetRandomSprite();
        gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    private Sprite GetRandomSprite(){
        return blocksSprites[Random.Range(0, blocksSprites.Count)];
    }
}
