using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBlocks : MonoBehaviour{
    [SerializeField] List<Sprite> blocksSprites;

    void Awake(){
        var randomSprite = GetRandomSprite();
        gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    Sprite GetRandomSprite(){
        return blocksSprites[Random.Range(0, blocksSprites.Count)];
    }
}
