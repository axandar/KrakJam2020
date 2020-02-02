using System.Collections;
using System.Collections.Generic;
using highScore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour{
	
	[SerializeField] private SceneAsset sceneSwitchTo;

	public void SwitchScene(){
		SceneManager.LoadScene(sceneSwitchTo.name);
	}

	public void ExitGame(){
		Application.Quit(0);
	}
}