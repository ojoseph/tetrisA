using UnityEngine;
using System.Collections;

public class goToCredits : MonoBehaviour {
	
	public AudioClip startScreenPingSound;
	
	void OnMouseDown(){
		
		 
		//print("some TEST CLICK "  + startScreenPingSound.length);
		
		audio.PlayOneShot(startScreenPingSound, 1.0F);
		animation.Play("startButtonAnim");
		StartCoroutine("goCredits");
		
		
	}
	
	
	
	IEnumerator goCredits(){
		yield return new WaitForSeconds(1);
		Application.LoadLevel("credits");	
	}
}
