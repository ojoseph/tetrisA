using UnityEngine;
using System.Collections;




public class scoreManager : MonoBehaviour {
	
public int scoreValue = 0;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
public void raiseScore() {
		scoreValue += 1;
	}
	
	
	
	//Debug Tool
	void OnGUI(){
		
		//Will handle updating the score.
		GUI.Label (new Rect (25, 25, 300, 300), "Score: " + scoreValue);
		
		
		
	}
	
	
	
}
