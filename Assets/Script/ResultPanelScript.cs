using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanelScript : MonoBehaviour {
	public GameObject[] star = new GameObject[3];
	public Sprite[] starIcon = new Sprite[2];
	public GameObject Result;
	public Sprite[] ResultSprite = new Sprite[2];
	public Text BestScore;
	public Text Score;
	int stars;
	public int level;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		stars =	DataService.Instance.prefs.GetLevel (level);
		if(stars == 0){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			Result.gameObject.GetComponent<Image>().sprite = ResultSprite [0];
		}
		if(stars == 1){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			Result.gameObject.GetComponent<Image>().sprite = ResultSprite [1];
		}
		else if(stars == 2){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon [0];
			Result.gameObject.GetComponent<Image>().sprite = ResultSprite [1];
		}
		else if(stars == 3){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			Result.gameObject.GetComponent<Image>().sprite = ResultSprite [1];
		}


		Score.text = stars.ToString ();
		BestScore.text = "Best Score : " + stars;
	}
	public void levels(){
		SceneManager.LoadScene(0);
	}
	public void nexTLevel(){
		SceneManager.LoadScene(level+1);
	}
	public void Reload(){
		SceneManager.LoadScene(level);
	}
}
