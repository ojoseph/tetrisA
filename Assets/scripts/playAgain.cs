using UnityEngine;
using System.Collections;

public class playAgain : MonoBehaviour {
	
	public AudioClip startScreenPingSound;
	
	void OnMouseDown(){
		
		 
		//print("some TEST CLICK "  + startScreenPingSound.length);
		
		audio.PlayOneShot(startScreenPingSound, 1.0F);
		animation.Play("startButtonAnim");
		StartCoroutine("restartGame");
		
		
	}
	
	
	
	IEnumerator restartGame(){
		yield return new WaitForSeconds(1);
		Application.LoadLevel("gameScene");	
	}
}
