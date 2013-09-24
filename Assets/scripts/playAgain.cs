using UnityEngine;
using System.Collections;

public class playAgain : MonoBehaviour {
	
	public AudioClip startScreenPingSound;
	
	void OnMouseDown(){
		//Application.LoadLevel("gameScene");	
		 
		//print("some TEST CLICK "  + startScreenPingSound.length);
		
		 audio.PlayOneShot(startScreenPingSound, 1.0F);
	}
}
