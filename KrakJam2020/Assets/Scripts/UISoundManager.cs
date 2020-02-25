using UnityEngine;

public class UISoundManager : MonoBehaviour{
	[SerializeField] private AudioSource audioSource;
	private static bool _created;

	private void Awake(){
		Debug.Log("Awake");
		if(!_created){
			DontDestroyOnLoad(gameObject);
			_created = true;
		}else{
			Destroy(gameObject, audioSource.clip.length);
		}
	}

	public void Play(){
		audioSource.Play();
	}
}