using UnityEngine;
using System.Collections;

public class testCreateCall : MonoBehaviour {
	
	//GameObj that serves to acces the GameManger
	GameObject connectToGameManager;
	 
	void OnMouseDown(){
		
		 
		connectToGameManager = GameObject.Find("gameManager");
		connectToGameManager.GetComponent<generateCube>().generateField();
		
	}
	
	
}
