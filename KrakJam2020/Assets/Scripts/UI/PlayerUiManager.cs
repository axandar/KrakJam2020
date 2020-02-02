using healthPointSystem;
using highScore;
using TMPro;
using UnityEngine;

public class PlayerUiManager : MonoBehaviour{
	[SerializeField] TextMeshProUGUI timeElapsedDisplayText;
	[SerializeField] TextMeshProUGUI pointsDisplayText;
	[SerializeField] TextMeshProUGUI HpDisplayText;
	
	[SerializeField] HighScore _highScore;
	[SerializeField] HealthPointsSystem _healthPointsSystem;
	
	void Update() {
		//TODO: execute methods from proper places/through events
		UpdateTimeElapsedText();
		UpdatePointsDisplayText();
		UpdateHpDisplayText();
	}

	public void UpdateTimeElapsedText() {
		timeElapsedDisplayText.text = _highScore.HighScoreEntry.TimePlayedInSeconds().ToString();
	}

	public void UpdatePointsDisplayText() {
		pointsDisplayText.text = "Score: " + _highScore.HighScoreEntry.Score.ToString();
	}

	public void UpdateHpDisplayText() {
		HpDisplayText.text = "HP: " + _healthPointsSystem.MaxHp.ToString();
	}
}
