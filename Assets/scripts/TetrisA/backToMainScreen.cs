using UnityEngine;
using System.Collections;

public class backToMainScreen : MonoBehaviour {
	
 	
	void OnMouseDown(){
		
		StartCoroutine("restartGame");
	}
	
	
	
	IEnumerator restartGame(){
		yield return new WaitForSeconds(0.3f);
		gameManager.theCurrGameState = gameManager.gameState.initialize;
		Application.LoadLevel("titleScreen");	
	}
}
