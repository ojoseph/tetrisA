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
	
	
	//We Start Playing
	public void playGame(){
		//We have to split this into phases to
		//print("We are playing the game");
		//We call the ftc for creating a map and start the mapSetUp process.
		
			//print ("Could it be?");
		
			gameplay thegameplay = GetComponent<gameplay>();
		
			thegameplay.theCurrentStatus = gameplay.currentStatus.notDoneYet;
		
		//We check if the process is done or not if so we move to the next phase, Else we do not.
		if(thegameplay.theCurrentStatus == gameplay.currentStatus.notDoneYet){
			
			//playerSlctColor
			thegameplay.playerSlctColor = 2;
			thegameplay.opponentSlctColor = 1;
			
			
			//If we havent created a map yet we make one.
			thegameplay.initMe();
			
		}else{
			
        	//If the process is already done we move on to the next phase
			theCurrGameState = gameState.none;
		}
	}
	
	
	
	//We Start Playing
	public void opponentTurn(){
		//We have to split this into phases to
		print("Its the opponent's TURN!!");
		//We call the ftc for creating a map and start the mapSetUp process.
		
		
		gameplay thegameplay = GetComponent<gameplay>();
		
		thegameplay.theCurrentStatus = gameplay.currentStatus.notDoneYet;
		
		//We check if the process is done or not if so we move to the next phase, Else we do not.
		if(thegameplay.theCurrentStatus == gameplay.currentStatus.notDoneYet){
		 
			print ("###TEST ELSE");
        	//If the process is already done we move on to the next phase
			theCurrGameState = gameState.none;
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	IEnumerator delay(string someName){
		
 		print("GO WITH: " + someName);
		
			yield return new WaitForSeconds(0.5f);
		if(someName != ""){
			
			print("I COLOR: " + someName);
			GameObject.Find(someName).renderer.material.color = Color.red;
		 
		}else{
			
			print ("CANT COLOR IT");
			
		}
		
		yield return new WaitForSeconds(2.0f);
		print("OK WE GO WITH: " + someName);
		
		if(someName != ""){
			print("I chose: " + someName);
			//theTempGameObj.GetComponent<replaceToken>().OnMouseDown();
			GameObject.Find(someName).GetComponent<replaceToken>().OnMouseDown();
		}else{
			print("Did not FIND THE TARGET");
			//print("I chose: " + theTempGameObj.name);
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	IEnumerator loadGameOver(){
//		print("FROM COROUTINE");
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("gameOver");
		theCurrGameState = gameState.none;
	}
	
	
	
 
	
	
	
	
	
	
	
	
 
	
	
 
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
