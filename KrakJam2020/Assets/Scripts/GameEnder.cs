using System.Collections;
using UnityEngine;

public class GameEnder : MonoBehaviour {
    [SerializeField] int gameLengthInSeconds;
    int _remainingGameTime;

    void Start() {
        _remainingGameTime = gameLengthInSeconds;
        StartCoroutine(CoundownRemainingGameTime());
    }

    IEnumerator CoundownRemainingGameTime() {
        while (_remainingGameTime > 0) {
            yield return new WaitForSeconds(1f);
            _remainingGameTime -= 1;
        }
        EndGame();
    }
    
    void EndGame() {
        //TODO: end game, load game ended scene
    }

}
