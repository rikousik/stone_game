using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public GameObject SettingPanel;
	public GameObject LevelPanel;
	public GameObject[] VolLevel = new GameObject[5];
	public Sprite[] VolSprite = new Sprite[2];
	int panel = 0;
	public int volume;
	public void LoadScene(int Level){
		SceneManager.LoadScene(Level);
	}

	public void Setting(){
		SettingPanel.SetActive (true);
		panel = 1;
	}
	public void Level(){
		LevelPanel.SetActive (true);
		panel = 2;
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
		if(panel == 1){
			SettingPanel.SetActive (false);
			panel = 0;
		}
		else if(panel == 2){
			LevelPanel.SetActive (false);
			panel = 0;
		}
			volume = DataService.Instance.prefs.GetVolume();
	}

}
	public void VolPlus(){
		if(volume<5){
			volume++;
			DataService.Instance.prefs.SetVolume (volume);
		}
		setSprite ();

	}
	public void VolMinus(){
		if(volume>0){
			volume--;
			DataService.Instance.prefs.SetVolume (volume);
		}
		setSprite ();
	}
	void setSprite(){
		for (int i = 0; i < volume; i++) {
			VolLevel [i].gameObject.GetComponent<Image> ().sprite = VolSprite [1];
		}	
		if (volume  < 5) {
			for (int i = volume; i < 5; i++) {
				VolLevel [i].gameObject.GetComponent<Image> ().sprite = VolSprite [0];
			}
		}
	}
}
