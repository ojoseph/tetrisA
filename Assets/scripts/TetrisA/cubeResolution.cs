using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class cubeResolution : MonoBehaviour {
	
	int prevCubeValue = 0;
	int currentCubeValue = 0;
	
	
	//Will hold in memory the cubes from the same color in that chain.
	List<string> memorizeCubesSet = new List<string>();
	
	//used to assign which direction we want to look at
	enum lookDirection{
		left,
		right,
		up,
		down 
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Use this for initialization
	public void testFct() {
		
		print ("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
		
	}
	
	
	
	public void resolve(){
		 
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0; theRow < theNumRows; theRow++){

			//We populate the rows
			for(int incre = 0; incre < 11 ; incre++){
				
				print ("<TTT>       " + createField.theTileNames[theRow, incre] + "     " + createField.theField[theRow, incre]);
				
				//If the current array contains a cube we start the loop.
				if(createField.theField[theRow, incre] != 0){
					
					print ("<X> We start to look from here for similar cubes <X>");
					
					//We call the function with the coordinates of the cube we found.
					lookForMatches(createField.theTileNames[theRow, incre]);
					
					
					
					
					
					
					//We recover the location in the table and send it to the function
					
					//We need to loop in 4 directions, Up  Down  Left  Right. 
					//On each directions we move a square at the time and look for several info.
					//	First one we check if the next case is not out of the array index
					//	We check if the next position is no empty, if so we stop our research.
					//	We check if the the cube is the same color as the one that triggered this loop. If not we stop it right away. 
					//	For each block that matches the initial block's color, we add its info in a table 
					//		We repeat the process for the other directions.
					
					
					
				}
				
				
				
				
			}
			
		}
		
		
		
	}
	
	//void lookForAvailable(lookDirection theWantedDirection ,int theRow, int incre, int firstTkenLocation){
	void lookForMatches( string theCubeWeFound){
		
			int indexCaseCheckHorizontal = 0;
			int indexCaseCheckVertical = 0;
			
		//We declare it before use
			lookDirection theWantedDirection;
		
			theWantedDirection = lookDirection.up;
		
			switch(theWantedDirection){
				case lookDirection.right:
					//int nextCaseCheck  = theField[theRow,incre + 1];
					indexCaseCheckHorizontal = +1;
				break;
				case lookDirection.left:
					//int nextCaseCheck  = theField[theRow,incre - 1];
					indexCaseCheckHorizontal = -1;
				break;
				case lookDirection.up:
					//int nextCaseCheck  = theField[theRow,incre + 1];
					indexCaseCheckVertical = + 1;
				break;
				case lookDirection.down:
					//int nextCaseCheck  = theField[theRow,incre - 1];
					indexCaseCheckVertical = -1;
				break;
			
			}
				
			
			int posTempVertical =  indexCaseCheckVertical;
			int posTempHorizontal = indexCaseCheckHorizontal;
		
		
		
		
			int theNumRows = (createField.theField.Length/10); 
			for(int theRow = 0; theRow < theNumRows; theRow++){
	
				//We populate the rows
				for(int incre = 0; incre < 11; incre++){
					
					//We try to recover the location,
					if(createField.theTileNames[theRow, incre] == theCubeWeFound){
						
						//We got the location so we move  in the direction previously dictated and try to find cubes or empty spaces within the arrays limits.
						
					
						int theIncreV  = indexCaseCheckVertical;
						int theIncreH  = indexCaseCheckHorizontal;
						while(createField.theField[theRow, incre] !=0 ){
							
							//We restrain the search within the table's size
							if(theIncreV < 10 && theIncreH < 7){
							
									print( "<###6###>" + createField.theTileNames[theRow, incre] );
							
							}
						
						
						
						
							theIncreV += indexCaseCheckVertical;
							theIncreH += indexCaseCheckHorizontal;
						}
					
					
					
					}
				
				}
			
			}
		
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
	
		
		
	}
	
	
	
	
}
