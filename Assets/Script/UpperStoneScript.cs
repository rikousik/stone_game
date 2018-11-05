using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperStoneScript : MonoBehaviour {
	public Sprite[] UpperStone ; 
	public int UpperCounter;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		Invoke ("SetSprite", 1);
	}
	
	// Update is called once per frame
	void SetSprite(){
		sr.sprite = UpperStone[UpperCounter];
	}
	void Update () {
		
	}
}
