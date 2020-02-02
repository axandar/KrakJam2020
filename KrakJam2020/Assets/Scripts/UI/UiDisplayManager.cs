using healthPointSystem;
using highScore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDisplayManager : MonoBehaviour {
	[SerializeField] TextMeshProUGUI timeElapsedDisplayText;
	[SerializeField] TextMeshProUGUI pointsDisplayText;
	[SerializeField] TextMeshProUGUI HpDisplayText;

	[SerializeField] HighScore _highScore;
	[SerializeField] HealthPointsSystem _healthPointsSystem;

	public void UpdateTimeElapsedText() {
		timeElapsedDisplayText.text = _highScore.HighScoreEntry.TimePlayedInSeconds().ToString();
	}

	public void UpdatePointsDisplayText() {
		pointsDisplayText.text = _highScore.HighScoreEntry.Score.ToString();
	}

	public void UpdateHpDisplayText() {
		HpDisplayText.text = _healthPointsSystem.MaxHp.ToString();
	}
}