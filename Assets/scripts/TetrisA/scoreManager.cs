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
		
		 
		//PlayerPrefs.DeleteKey("registeredScore");
		if( scoreValue > topScore){
			//We Save the score
			PlayerPrefs.SetInt("registeredScore", scoreValue);
		}
	}
	
	
	
	//Debug Tool
	void OnGUI(){
		
		//Will handle updating the score. and we multiply it by 10 to make it look cool
		GUI.Label (new Rect (25, 25, 400, 300), "Score: " + scoreValue*10 );
		GUI.Label (new Rect (25, 45, 400, 300), "Top Score: " +  topScore*10);
		
		
	}
	
	
	
}
