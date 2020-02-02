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
        while (RemainingGameTime > 0) {
            yield return new WaitForSeconds(1f);
            _remainingGameTime = RemainingGameTime - 1;
        }
        EndGame();
    }
    
    void EndGame() {
        //TODO: end game, load game ended scene
    }

    public int RemainingGameTime => _remainingGameTime;
}
