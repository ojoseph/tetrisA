using UnityEngine;
using System.Collections;

public class generateCube : MonoBehaviour {
	
	
	
	//GameObbject for the tiles
	GameObject aCube;
	GameObject btnCube;
	
	
	//Checks if we can generate the cube
	bool generateBtn = false;
 	
	//Checks if there  is any cube in the row
	bool anycubeInRow = false;
	
	public GameObject[] gameObjects;
	
	
	// A. 2D array of strings.Where we store the names
	public static string[] theTagsList = new string[] { "pinkHeart", "greenSquare", "blueStar", "yellowTriangle", "purpleSpade","rowDownBtn","rowUpBtn" };
	
	
	// Use this for initialization
	void Start () {
		
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10); 
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
		
	 
	
	

	public void generateField(){
		
		
		
		
		
		
		//Before we check if the is any value in a row //For the button generation
		int theSomeNumRows = (createField.theField.Length/7);
		for(int someTheRow = 0 ; someTheRow < theSomeNumRows; someTheRow++){
			
			anycubeInRow = false; 
			
//			print("======================================");
			
			for(int otherTncre = 0; otherTncre < 7; otherTncre++){
			
//				print ("< E > : " + createField.theTileNames[otherTncre,someTheRow] + "   " + createField.theField[otherTncre,someTheRow] );
				
				if( createField.theField[otherTncre,someTheRow] != 0){
					//print("WOOOOT a cube Is NotT empTy in thIs RoW?!");
					anycubeInRow = true;
//			 		print ("< E > : " + createField.theTileNames[otherTncre,someTheRow] + "   " + createField.theField[otherTncre,someTheRow] );
				}
				
				
				
			}
			
			
			
//			print("===================  END " + anycubeInRow + "  ===================");
			
			//If there is no cubes available we end up this madness.
			if(anycubeInRow == false){
				//We dint find anything so we break
				break;
			}
			
			//Print out the first and last position
//			print ("<0> First pos in this: " + createField.theTileNames[0,someTheRow] );
//			print ("<0> Last pos in this: " + createField.theTileNames[6,someTheRow] );
			
			//////////////
			//if(anycubeInRow == true){	
//				print("We add a box in here");
				GameObject targetBtnDownLoc = new GameObject();
				targetBtnDownLoc = GameObject.Find(createField.theTileNames[0,someTheRow]);
			
				btnCube = Instantiate( Resources.Load("blocks/upDown"),  new Vector3(targetBtnDownLoc.transform.position.x, 0, targetBtnDownLoc.transform.position.z), transform.localRotation) as GameObject;
				btnCube.name = "rowUpBtn" + createField.theTileNames[0,someTheRow ];
				btnCube.tag = "rowUpBtn";
				btnCube.AddComponent("moveRowUp");
				
			
			
//				print("We add a box in here");
				//GameObject targetBtnDownLoc = new GameObject();
				targetBtnDownLoc = GameObject.Find(createField.theTileNames[6,someTheRow]);
			
				btnCube = Instantiate( Resources.Load("blocks/upDown"),  new Vector3(targetBtnDownLoc.transform.position.x, 0, targetBtnDownLoc.transform.position.z), transform.localRotation) as GameObject;
				btnCube.name = "rowDownBtn_" + createField.theTileNames[6,someTheRow ];
				btnCube.tag = "rowDownBtn";
				btnCube.AddComponent("moveRowUp");
				
			//}
			////////////////
			
			 
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
		}
		
		
		
		
//		print ("2222222222222222222222222");
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10);  
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
//			print ("< R > Done with a row, so We Roll, we Roll  Row: " + theRow);
			
			//We start a new row therfore we havent encounter any empty space
			generateBtn = false;
				
			//We reset and check again if anything has been found.	
			anycubeInRow = false;
		 
			
			//We populate the rows
			for(int incre = 0; incre < 11; incre++){
					
				//print ("< E > : " + createField.theTileNames[theRow,incre] + "    " + createField.theField[theRow,incre]);
			 
				
				//We have encountered an empty space, we let the box know that it has to stop generating btns
				if(createField.theField[theRow,incre] == 0){
					generateBtn = true;
				}
				
				
				
				
				if(createField.theField[theRow,incre] != 0){
				 
					
					///print ("< T > Create Button? : " + incre);
				
//					print ("< F > : " + createField.theTileNames[theRow,incre]);
					
					//print ("8:   "  +  createField.theTileNames[theRow,incre] + "    " + createField.theField[theRow,incre]);
					
					//We check we can generate new tokens or not. 
					/*if(generateBtn == false ){
						if( theRow == 6  ){
								
							print("We add a box in here");
							GameObject targetBtnDownLoc = new GameObject();
							targetBtnDownLoc = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							btnCube = Instantiate( Resources.Load("blocks/upDown"),  new Vector3(targetBtnDownLoc.transform.position.x, 0, targetBtnDownLoc.transform.position.z), transform.localRotation) as GameObject;
							btnCube.name = "rowDownBtn_" + createField.theTileNames[ theRow,incre ];
							btnCube.tag = "rowDownBtn";
						}
						
						
						if( theRow == 0 ){
								
							print("We add a box in here");
							GameObject targetBtnDownLoc = new GameObject();
							targetBtnDownLoc = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							btnCube = Instantiate( Resources.Load("blocks/upDown"),  new Vector3(targetBtnDownLoc.transform.position.x, 0, targetBtnDownLoc.transform.position.z), transform.localRotation) as GameObject;
							btnCube.name = "rowUpBtn" + createField.theTileNames[ theRow,incre ];
							btnCube.tag = "rowUpBtn";
						}
						
					}*/
					
					
					
					
					/*==================*/
					/* ==== Cube Types ====*/
					
					// [0]	Empty	 
					// [1]	Heart
					// [2]	Star
					// [3]	Triangle
					// [4]	Square
					// [5]	Spade
					
					
					switch(createField.theField[theRow,incre]){
					 
						case 1:
						
							//print("Creating Pink HEART");
						
							GameObject targetLoc1 = new GameObject();
							targetLoc1 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/heart"),  new Vector3(targetLoc1.transform.position.x, 0, targetLoc1.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
							aCube.tag = "pinkHeart";
						
						break;
						
						case 2:
							
							//print("Creating Blue STAR");
						
							GameObject targetLoc2 = new GameObject();
							targetLoc2 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/star"),  new Vector3(targetLoc2.transform.position.x, 0, targetLoc2.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
							aCube.tag = "blueStar";
						
						break;
						
						case 3:
							
							//print("Creating TRIANGLE");
						
							GameObject targetLoc3 = new GameObject();
							targetLoc3 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/triangle"),  new Vector3(targetLoc3.transform.position.x, 0, targetLoc3.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
							aCube.tag = "yellowTriangle";
						 
						break;
						
						case 4:
						
							//print("Creating SQUARE GREEN");
							
							GameObject targetLoc4 = new GameObject();
							targetLoc4 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/square"),  new Vector3(targetLoc4.transform.position.x, 0, targetLoc4.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
							aCube.tag = "greenSquare";
						 
						break;
						
						case 5:
						
							//print("Creating SPADE PURPLE");
						
							GameObject targetLoc5 = new GameObject();
							targetLoc5 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/spade"),  new Vector3(targetLoc5.transform.position.x, 0, targetLoc5.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
							aCube.tag = "purpleSpade";
						
						
						break;
						
						
						
					}
					
					
				 
				 
				}
				
			}
			
			
			
			
			
		}//End Generating 
		
	}
	

	
	public void deleteAllCubes(){
		
		
		 
		
		for(int t = 0; t < theTagsList.Length; t++){
		gameObjects = GameObject.FindGameObjectsWithTag (theTagsList[t]);
 		/*gameObjects = GameObject.FindGameObjectsWithTag ("greenSquare"); 
		gameObjects = GameObject.FindGameObjectsWithTag ("blueStar");*/ 
		
		
			for(var i = 0 ; i < gameObjects.Length ; i ++){
				
				Destroy(gameObjects[i]);
				
				//A simple message that let us know that all ttags from this section are done.
				if( i == gameObjects.Length - 1){
					
					//We look for the next tag row
					//print ("We took out one tag Set: " + theTagsList[t]);
					
				}
				
			}
		}
		
	}
	
	
	
	
	
}

