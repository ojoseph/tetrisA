using UnityEngine;
using System.Collections;




public class scoreManager : MonoBehaviour {
	
public int scoreValue = 0;
	int topScore;
	
	// Use this for initialization
	void Start () {
		topScore = PlayerPrefs.GetInt("registeredScore");
	}
	
	// We raise the player score
	public void raiseScore() {
		
		//We raise the score up
		scoreValue += 1;
		
		if( scoreValue > topScore){
			//We Save the score
			PlayerPrefs.SetInt("registeredScore", scoreValue);
		}
	}
	
	
	
	//Debug Tool
	void OnGUI(){
		
		//Will handle updating the score.
		GUI.Label (new Rect (25, 25, 300, 300), "Score: " + scoreValue +"   Top Score: " +  topScore);
		
		
		
	}
	
	
	
}
