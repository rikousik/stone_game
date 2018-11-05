using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

	public GameObject Stone, UpStone;
	public ArrayLayout UpperSet;
	public ArrayLayout LowerSet;
	Vector3[,] LowerPos = new Vector3[9, 9];
	Vector3[,] UpperPos = new Vector3[9, 9];
	public GameObject[,] LowerStones = new GameObject[9, 9];
	public GameObject[,] UpperStones = new GameObject[9, 9];
	float x, y, UpX, UpY;
	public bool mt = false;
	public int Level;
	public  float timeLeft ;
	public Text Timertext;
	public Text LevelText;
	public GameObject ResultPanel;



	void Start ()
	{	timeLeft = 30f;
		x = -1.746f;
		y = -1.524f;
		UpX = -1.746f;
		UpY = 3.656f;
		SetPos ();
		SetStone ();
		SetUpperPos ();
		SetUpperStone ();
	//	Matched = false;
		LevelText.text = Level.ToString();
	}


	void Update ()
	{
		
		if(CheckResult()){
			mt = true;
			if(timeLeft>25){
				DataService.Instance.prefs.SetLevel (Level, 3);
			}
			else if(timeLeft > 19 && timeLeft <25){
				DataService.Instance.prefs.SetLevel (Level, 2);
			}
			else if( timeLeft <9){
				DataService.Instance.prefs.SetLevel (Level, 1);
			}
			ResultPanel.SetActive (true);
		}
		if (mt == false) {
			timeLeft -= Time.deltaTime;
		
			Timertext.text = Mathf.Round (timeLeft).ToString ();
			if (timeLeft < 0) {
				DataService.Instance.prefs.SetLevel (Level, 0);
				ResultPanel.SetActive (true);
			}
		}
	//	DataService.Instance.prefs.SetLevel (1, test);
	//	getTest = DataService.Instance.prefs.GetLevel (1);
	}

	void SetPos ()
	{
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				LowerPos [i, j] = new Vector3 (x, y, 0f);
				x = x + 0.432f;
			}
			y = y - 0.432f;
			x = -1.746f;
		}
	}
	void SetUpperPos ()
	{
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				UpperPos [i, j] = new Vector3 (UpX, UpY, 0f);
				UpX = UpX + 0.432f;
			}
			UpY = UpY - 0.432f;
			UpX = -1.746f;
		}
	}

	void SetStone ()
	{
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				int	Counter = LowerSet.rows [i].row [j];
				if (Counter > 0 && Counter < 6) {
					LowerStones [i, j] = GameObject.Instantiate (Stone) as GameObject;
					LowerStones [i, j].transform.position = LowerPos [i, j]; 
				//	SideAnim[i,j] = LowerStones [i,j].gameObject.GetComponent<Animator>(); 
					LowerStones [i, j].gameObject.GetComponent<StoneScript> ().counter = Counter - 1;
					LowerStones [i, j].gameObject.GetComponent<StoneScript> ().x = i;
					LowerStones [i, j].gameObject.GetComponent<StoneScript> ().y = j;
				}
			}
		}
	}
	void SetUpperStone(){
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				int	Counter = UpperSet.rows [i].row [j];
				if (Counter > 0 && Counter < 6) {
//					SideAnim [i, j].SetTrigger ("change");
					UpperStones [i, j] = GameObject.Instantiate (UpStone) as GameObject;
					UpperStones [i, j].transform.position = UpperPos [i, j]; 
					UpperStones [i, j].gameObject.GetComponent<UpperStoneScript> ().UpperCounter = Counter - 1;
				}
			}
		}
	}


	bool CheckResult(){
		bool Matched = true;
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				if(UpperSet.rows [i].row [j] !=  LowerSet.rows [i].row [j]){
					Matched = false;
				}
			}
		}
		return Matched;
	}
	public void ChangeSideColour (int i, int j)
	{
		if (i<9 && j<9) { 
			if (i > -1 && j > -1) {
				int SideCounter = LowerSet.rows [i].row [j];
				if (SideCounter > 0 && SideCounter < 6) {
					LowerStones [i, j].gameObject.GetComponent<StoneScript> ().counter++;
					LowerSet.rows [i].row [j] = LowerStones [i, j].gameObject.GetComponent<StoneScript> ().counter;
					LowerStones [i, j].gameObject.GetComponent<StoneScript> ().MyUpdate ();
				}
			}
		}
	}
}

