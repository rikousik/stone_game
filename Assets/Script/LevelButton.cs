using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
	public GameObject[] star = new GameObject[3];
	public int stars;
	public int level;
	public Sprite[] starIcon = new Sprite[2];
	public Text Leveltext;
	void Start () {
		Leveltext.text =  level.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		stars =	DataService.Instance.prefs.GetLevel (level);

		if(stars == 0){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[0];
		}
		if(stars == 1){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[0];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[0];
		}
		else if(stars == 2){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon [0];
		}
		else if(stars == 3){
			star [0].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [1].gameObject.GetComponent<Image> ().sprite = starIcon[1];
			star [2].gameObject.GetComponent<Image> ().sprite = starIcon[1];
		}
	}
}
