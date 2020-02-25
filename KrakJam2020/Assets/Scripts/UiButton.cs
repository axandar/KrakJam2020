using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
	
	[SerializeField] private Vector3 enlargedScale = new Vector3(1.5f, 1.5f, 1.5f);

	private Vector3 _cachedScale;
	
	void Start(){
		_cachedScale = transform.localScale;
		var button = GetComponent<Button>();
		var obj = GameObject.FindWithTag(Tags.UI_SOUND_MANAGER);
		var uiSoundManager = obj.GetComponent<UISoundManager>();
		button.onClick.AddListener(uiSoundManager.Play);
	}

	public void OnPointerEnter(PointerEventData eventData){
		transform.localScale = enlargedScale;
	}

	public void OnPointerExit(PointerEventData eventData){
		transform.localScale = _cachedScale;
	}
}