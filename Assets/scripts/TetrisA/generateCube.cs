using UnityEngine;
using System.Collections;

public class generateCube : MonoBehaviour {
	
	
	
	//GameObbject for the tiles
	GameObject aCube;
	
	
	// Use this for initialization
	void Start () {
		
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10); 
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
		
	 
	
	

	public void generateField(){
		
		
		print ("2222222222222222222222222");
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10);  
		
		//We set the rows
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 0; incre < 11; incre++){
				
				print ("8:   "  +  createField.theTileNames[theRow,incre] + "    " + createField.theField[theRow,incre]);
				
				if(createField.theField[theRow,incre] != 0){
				 
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
						
							print("Creating Pink HEART");
						
							GameObject targetLoc1 = new GameObject();
							targetLoc1 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/heart"),  new Vector3(targetLoc1.transform.position.x, 0, targetLoc1.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
						
						break;
						
						case 2:
							
							print("Creating Blue STAR");
						
							GameObject targetLoc2 = new GameObject();
							targetLoc2 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/star"),  new Vector3(targetLoc2.transform.position.x, 0, targetLoc2.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
						
						break;
						
						case 3:
							
							print("Creating YELLOW TRIANGLE");
						
							GameObject targetLoc3 = new GameObject();
							targetLoc3 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/triangle"),  new Vector3(targetLoc3.transform.position.x, 0, targetLoc3.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
						
						 
						break;
						
						case 4:
						
							print("Creating YELLOW SQUARE GREEN");
							
							GameObject targetLoc4 = new GameObject();
							targetLoc4 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/square"),  new Vector3(targetLoc4.transform.position.x, 0, targetLoc4.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
						
						 
						break;
						
						case 5:
						
							print("Creating YELLOW SPADE PURPLE");
						
							GameObject targetLoc5 = new GameObject();
							targetLoc5 = GameObject.Find(createField.theTileNames[theRow,incre]);
						
							aCube = Instantiate( Resources.Load("blocks/spade"),  new Vector3(targetLoc5.transform.position.x, 0, targetLoc5.transform.position.z), transform.localRotation) as GameObject;
							aCube.name = createField.theTileNames[ theRow,incre ];
						
						break;
						
						
						
					}
					
					
				 
				 
				}
				
			}
			
		}//End Generating 
		
	}
	
	
	void deleteAllCubes(){
		
		
	}
	
	
	
	
	
}

