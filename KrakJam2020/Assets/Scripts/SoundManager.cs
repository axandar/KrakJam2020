using UnityEngine;

public class SoundManager : MonoBehaviour{
	[SerializeField] private AudioSource audioSource;
	private static bool _created;

	private void Awake(){
		if(!_created){
			DontDestroyOnLoad(gameObject);
			_created = true;
		}else{
			Destroy(gameObject, audioSource.clip.length);
		}
	}

	public void PlaySfx(AudioClip audioClip){
		if(audioClip != null){
			audioSource.PlayOneShot(audioClip);
		}
	}
}