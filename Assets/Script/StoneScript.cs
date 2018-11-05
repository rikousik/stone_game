using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {
	public int counter,x,y,a,b,c,d;
	public Sprite[] stone ; 
	SpriteRenderer sr;
	public GameObject GM;
	Animator anim_main;

	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		anim_main = this.gameObject.GetComponent<Animator>();
		GM = GameObject.FindGameObjectWithTag ("GameController").gameObject;
		a = x + 1;
		b = x - 1;
		c = y + 1;
		d = y - 1;

		if (counter > 4) {
			counter = 0;
			GM.gameObject.GetComponent<GameScript> ().LowerSet.rows [x].row [y] = 0;
		//	anim_main.SetTrigger ("vanish");

			//			

		} else {
		//	anim_main.SetTrigger ("change");
			sr.sprite = stone [counter];
			GM.gameObject.GetComponent<GameScript> ().LowerSet.rows [x].row [y] = counter + 1;
		}
	}

	void OnMouseDown(){
		counter=counter+2;
		MyUpdate ();
		GM.gameObject.GetComponent<GameScript> ().ChangeSideColour (a,y);
		GM.gameObject.GetComponent<GameScript> ().ChangeSideColour (b,y);
		GM.gameObject.GetComponent<GameScript> ().ChangeSideColour (x,c);
		GM.gameObject.GetComponent<GameScript> ().ChangeSideColour (x,d);

	}
	public	void MyUpdate () {
		if (counter > 4) {
			counter = 0;
			GM.gameObject.GetComponent<GameScript> ().LowerSet.rows [x].row [y] = 0;
			anim_main.SetTrigger ("vanish");

			//			

		} else {
			anim_main.SetTrigger ("change");
			sr.sprite = stone [counter];
			GM.gameObject.GetComponent<GameScript> ().LowerSet.rows [x].row [y] = counter + 1;
		}

	}

	public void Destroy(){
		Destroy (this.gameObject);
	}
}
