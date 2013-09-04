using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {
	
	
	public enum gameState{
		none,
		initialize,
		playGame,
		gameOver 
	}
	
	public static gameState theCurrGameState;
	
	public enum playState{
		movingCubes,
		executingTask,
		player,
		opponent
		
	}
	public static playState currPlayState; 
	/*public enum whoTurns{
		waitingPlayer,
		waitingOpponent,
		player,
		opponent
		
	}*/
	
	//public static whoTurns theCurrTurn;
 
	
	
	// Use this for initialization
	void Start () {
		
		//We Init the game
		theCurrGameState = gameState.initialize;
		
		//theCurrTurn = whoTurns.player;
	}
	
	
	//used to assign which direction we want to look at
	enum lookDirection{
		left,
		right,
		up,
		down,
		diagUpLeft,
		diagUpRight,
		diagDownLeft,
		diagDownRight
	}
	
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		switch(theCurrGameState){
			
			case gameState.initialize:
				initialize();
			break;
			
			case gameState.playGame:
			 
				switch(currPlayState){
					
					case  playState.movingCubes:
						print ("<!> gameEngine <!>");
				
						gameEngine theGameEngine = GetComponent<gameEngine>();
						theGameEngine.initMe();
				
						currPlayState = playState.executingTask; 
					break;
				}
			
			break;
			
			case gameState.gameOver:
				//loadGameOverGameManager();
				StartCoroutine("loadGameOver");
			break;
		}
	}
	
	
	
	//Here we create the Map
	void initialize(){
		
		//we init the app
		this.GetComponent<createField>().initMe();
		//We change the game status
		theCurrGameState = gameState.playGame;
		
		
	}
	
	
 
	 
	
	
	IEnumerator loadGameOver(){
//		print("FROM COROUTINE");
		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel("gameOver");
		theCurrGameState = gameState.none;
	}
	
	
	
 
	
	
	
	
	
	
	
	
 
	
	
 
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
