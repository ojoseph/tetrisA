using UnityEngine;
using System.Collections;

public class createField : MonoBehaviour {
	
	
	public enum currentStatus{
		notDoneYet,
		taskComplete
	}
	
	//This process progression
	public static currentStatus theCurrentStatus = currentStatus.notDoneYet;
	
	//GameObbject for the tiles
	GameObject theTile;
	
	//GameObbject for the tiles
	GameObject aCube;


	//Sets the spacing between each tiles
	public float gridSpacing = 4.2f;
	
	//Decides how high does the token stands [FIX]
	private float tokenHeight = 0.45f; 
	
	
	string compile;
	
	//-----------------------------------------------------------------------------------------------------------------------
		
	//Should be 6X13 => Currently 6X10
	
	// A. 2D array of ints.
	public static int[,] theField = new int[,]
	{
	    {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 110}, //A
		{20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 220}, //B
		{30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 330}, //C
		{40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 440}, //D
		{50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 550}, //E
		{60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 660}, //F
		{70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 770}, //G
	};
	
	
	
	// A. 2D array of strings.Where we store the names
	public static string[,] theTileNames = new string[,]
	{
	    {"A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11"}, //A 0
		{"B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11"}, //B 1
		{"C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "C11"}, //C 2
		{"D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "D11"}, //D 3
		{"E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "E10", "E11"}, //E 4
		{"F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11"}, //F 5
		{"G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "G10", "G11"}, //G 6
	};
	
	
	
	/*==================*/
	/* ==== Cube Types ====*/
	
	// [0]	Empty	 
	// [1]	Heart
	// [2]	Star
	// [3]	Triangle
	// [4]	Square
	// [5]	Spade
	
	
	// Holds the cubeTypes
	public static int[,] cubeType = new int[,]
	{
	   {1, 2, 3, 4, 5}, 
	};
	
	//Let us know how many elm there is perRow
	public int elmByRows = 10;
	
	int slctRndCube;
	int slctPrevRndCube; 
	
	
	int rowSlctRndCube;
	int rowSlctPrevRndCube; 
	
	//-----------------------------------------------------------------------------------------------------------------------
	
	
	// Use this for initialization
	public void initMe () {
		
		//Resets the data in the table
		softReset();
		
		//Set the baseBlocks
		setDefaultBlocks();
		
		//Creates the field.
		makeField();
		
		//We generate the blocks
		//generateField();
		
		//We say that the task is complete .
		theCurrentStatus = currentStatus.taskComplete;
		
	}
	
	
	//////////////////////////////////////
	// [ STEP1 ]  MAKE FIELD : We make a simple field
	void makeField(){
		
		 //print(theField.Length/10);
		
		//Get the number of rows
		int theNumRows = (theField.Length/elmByRows); 
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 0; incre < 11; incre++){
				
				theTile = Instantiate(Resources.Load("tile"),  new Vector3(incre*gridSpacing, 0, (theRow+3)*gridSpacing)/*transform.localPosition*incre*/, transform.localRotation) as GameObject;
				theTile.name = theTileNames[ theRow,incre ];
				
				//We print the names for a test.
				//print (theTileNames[theRow,incre ]);
			}
			
		}//End Generating 
		
		
		//[ NEXT ] We place the tokens
		//placeTokens(theField);
	}
	
	
	
	//////////////////////////////////////
	// [ TOOL ]  SOFT RESET: Takes care of cleaning the arrays so that we ahve a clean table
	void softReset(){
		
		//Get the number of rows
		int theNumRows = (theField.Length/elmByRows);  
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 0; incre < 11; incre++){
			
				theField[theRow,incre] = 0;	
				//We print the names for a test.
				//print (theTileNames[theRow,incre ]);
			}
			
		}//End Generating 
	}
	
	
	
	
	void setDefaultBlocks(){	
		
		//Get the number of rows
		int theNumRows = (theField.Length/elmByRows); 
		
		
		
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 1; incre < 2; incre++){
				
				//If the new selected item is the same we reselect
				if(slctRndCube == slctPrevRndCube){
				//	print("RESELECT");
					
					//We do a first reselection A1 -> A2
					//We do a second reselection through the rows A1 -> B1
					while(slctRndCube == slctPrevRndCube){
						//print ("We reselect");
						slctRndCube = Random.Range(1, cubeType.Length + 1);
					}	
				 	
					
					
				}else{ 
				
					slctRndCube = Random.Range(1, cubeType.Length + 1);
				}
				
				slctPrevRndCube = slctRndCube;
				theField[theRow,incre] = slctRndCube; 
				 
			}
			
		}//End Generating 
		
		
		
		
		
		//Reselect for better precision by rows
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
				
			//We populate the rows
			for(int incre = 0; incre < 1; incre++){
				//print("Curr" +  + " Prev");
				//print ("Pull out the rows" + theTileNames[theRow,incre] + "   " + theField[theRow,incre]);
				
				//rowSlctRndCube = 0;
				if(rowSlctRndCube == rowSlctPrevRndCube){
					
					//print("ROW RESELECT" + theTileNames[theRow,incre] + "   " + theField[theRow,incre]);
					while(rowSlctRndCube == rowSlctPrevRndCube){
						//print ("We reselect");
						rowSlctRndCube = Random.Range(1, cubeType.Length+1);
					}
					
				}else{
					
					rowSlctRndCube = Random.Range(1, cubeType.Length+1);
				}
				
				rowSlctPrevRndCube = rowSlctRndCube; 
				theField[theRow,incre] = rowSlctRndCube; 
				
			}
			
		 
			
		}
		
		//End Reselect
		
		
		
		
	}
	
	
	void generateField(){
		
		//Get the number of rows
		int theNumRows = (theField.Length/elmByRows);  
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 0; incre < 11; incre++){
				
				if(theField[theRow,incre] != 0){
				 
					/*==================*/
					/* ==== Cube Types ====*/
					
					// [0]	Empty	 
					// [1]	Heart
					// [2]	Star
					// [3]	Triangle
					// [4]	Square
					// [5]	Spade
					
					
					switch(theField[theRow,incre]){
						case 1:
						
							GameObject targetLoc1 = new GameObject();
							targetLoc1 = GameObject.Find(theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/heart"),  new Vector3(targetLoc1.transform.position.x, 0, targetLoc1.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = theTileNames[ theRow,incre ];
						
						break;
						
						case 2:
							
							GameObject targetLoc2 = new GameObject();
							targetLoc2 = GameObject.Find(theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/star"),  new Vector3(targetLoc2.transform.position.x, 0, targetLoc2.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = theTileNames[ theRow,incre ];
						
						break;
						
						case 3:
							
							GameObject targetLoc3 = new GameObject();
							targetLoc3 = GameObject.Find(theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/triangle"),  new Vector3(targetLoc3.transform.position.x, 0, targetLoc3.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = theTileNames[ theRow,incre ];
						
						 
						break;
						
						case 4:
							
							GameObject targetLoc4 = new GameObject();
							targetLoc4 = GameObject.Find(theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/square"),  new Vector3(targetLoc4.transform.position.x, 0, targetLoc4.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = theTileNames[ theRow,incre ];
						
						 
						break;
						
						case 5:
						
							GameObject targetLoc5 = new GameObject();
							targetLoc5 = GameObject.Find(theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/spade"),  new Vector3(targetLoc5.transform.position.x, 0, targetLoc5.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = theTileNames[ theRow,incre ];
						
						break;
						
						
						
					}
					
					
					 
				 
				}
				
			}
			
		}//End Generating 
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	//For Displays the info
	void Update(){
		
		//Updates the table info
		tableMapInfo();
		
	}
	
	
	void tableMapInfo(){
		
		compile = "";
		int theNumRows = (theField.Length/elmByRows);  
		
		//Check each Entry in the table and we print it out
		for(int theRow = theNumRows-1 ; theRow >= 0; theRow--){
			
			//print("ROWS CEHCK " + theRow);
			
			for(int incre = 10; incre >= 0; incre--){
				
				//print("INCREEE CEHCK " + incre);	
				compile += theTileNames[theRow, incre] + ":   " + theField[theRow, incre].ToString() + "     ";
			}
			
			compile += "\n";
		}	
		
		
	}
	
	//Debug Tool
	void OnGUI(){
		
		GUI.Label (new Rect (25, 550, 3000, 300), "Array:\n" + compile);
		
	}
	
	
	
	
	
}
