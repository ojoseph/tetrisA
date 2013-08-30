using UnityEngine;
using System.Collections;

public class gameEngine : MonoBehaviour {
	
	
	public enum currentStatus{
		notDoneYet,
		taskComplete
	}
	
	//////////////////////////////////////////////////////////////////////
	//For the Import
	
	/*public static int[,] impTheField = new int[,]
	{
	    {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 110}, //A
		{20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 220}, //B
		{30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 330}, //C
		{40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 440}, //D
		{50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 550}, //E
		{60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 660}, //F
		{70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 770}, //G
	};*/
	
	//Cube
	// A. 2D array of ints.
	public static int[,] cubeFormTest = new int[,]
	{
	    {4}, //A
		{1}, //B
		{1}, //C
		{0}, //D
		{1}, //E
		{5}, //F
		{2}, //G
	};
	
	
	public static int[,] cubeFormTest2 = new int[,]
	{
	    {5,2}, //A
		{0,0}, //B
		{0,0}, //C
		{0,0}, //D
		{0,5}, //E
		{0,2}, //F
		{0,0}, //G
	};
	
	
	
	
	
	
	//Need to create a cube pool
	
	
	
	
	//Checking rows
	int changeRow = (createField.theField.Length/7)-1;
	
	int nextBelow1 = 1;
	
	
	//GameObj that serves to acces the GameManager
	GameObject connectToGameManager;
	
	//int smallTestCube = 0;
	
	
	
	
	
	/*==================*/
	/* ==== Cube Types ====*/
	
	// [0]	Empty	 
	// [1]	Heart
	// [2]	Star
	// [3]	Triangle
	// [4]	Square
	// [5]	Spade
	
	
	
	
	
	
	
	
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	

	
	
	// Use this for initialization
	public void initMe (){
		
		
		print("++++++++++  " +  changeRow  + "  ++++++++++");
		
		importMapData();
		
		//every seconds we move the blocks 
		
		/*print("***" + Random.Range(0,(createField.theField.Length-1)/10));
		
		smallTestCube = Random.Range(1,5);*/
	 
 
		//0. We create a row and add the info in the array.
		//1. We loop thriugh the cubes we want to add.		
		//2. We copy all the info into the top row of the array
		//3. We generate the cube's visual      //3a. We delete all the cubes that were on the scene.
		//4. We start moving them until there is no space for them to move.  //4a. We look below and make sure we are not out of range. We check if the next row is empty. If so, we move the cubes a row below
		//5. We find the matches and delete any match of 3 or more. 
				
				
		print("####"  + createField.theTileNames[0,10]);
		
		//Step 1
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//We populate the rows
			for(int incre = 0; incre < 1; incre++){
				
				print("%  " +  createField.theTileNames[ theRow, 10 ] + "   " + createField.theField[ theRow, 10 ] );
				
			}
			
		}	
		
		
		
		
		
		
		//Step 2
		
		/*for(int u = 0; u <  cubeFormTest.Length; u++ ){
			
			 
			//we copy the info and see what happens
			createField.theField[ u, 10 ] = cubeFormTest[u , 0];
			//print ("###  " + createField.theField[ u, 10 ] + "    "  + createField.theTileNames[ u, 10 ] + "   // " + cubeFormTest[u , 0]);
		}*/
		
		
		//print("</~/> " + cubeFormTest2.Length/7 );
		
		for(int w = 0; w < cubeFormTest2.Length/7 ;w++){
			
			
			//print ("<!> check Rows: " + cubeFormTest2[0 , w]);
			
			for(int u = 0; u <  cubeFormTest2.Length/2; u++ ){
			
				print ("<!> check Rows: " + cubeFormTest2[u , w]);
				//we copy the info and see what happens
				createField.theField[ u, 10-w ] = cubeFormTest2[u , w];
				//createField.theField[ u, 10 ] = cubeFormTest2[u , 0];
				//print ("###  " + createField.theField[ u, 10 ] + "    "  + createField.theTileNames[ u, 10 ] + "   // " + cubeFormTest[u , 0]);
				
			}
			
		}
		
		
		/*for(int u = 0; u <  cubeFormTest2.Length/2; u++ ){
			
			 
			//we copy the info and see what happens
			createField.theField[ u, 10 ] = cubeFormTest2[u , 0];
			//print ("###  " + createField.theField[ u, 10 ] + "    "  + createField.theTileNames[ u, 10 ] + "   // " + cubeFormTest[u , 0]);
			
		}*/
			
		
		
		
		//Step 3
		
		generateCube theGenerateCube = GetComponent<generateCube>();
		theGenerateCube.generateField();
		 
		
		
		
		
		//We start by calling the fct
		Invoke("moveBlocks", 1);
		
		
	}
	
	
	void moveBlocks(){
		
		//Step4
		
		//Get the number of rows
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0 ; theRow < theNumRows; theRow++){
			
			//print( "<////>" + createField.theTileNames[ theRow, changeRow]);
			//We populate the rows
			for(int incre = 0; incre < 2 ; incre++){
				
				//print("%  " +  createField.theTileNames[ theRow, 10 ] + "   " + createField.theField[ theRow, 10 ] );
				
				// 1. We check for the next position while within the table range.
				// 2. If we are still within the range, We check if the next position is free. If so we move, if not we leave it is.
				
				print ("< WWW> " + (changeRow + nextBelow1));
				
				//We make sure we dont get out of the index, when we reduce 1 or when we add 1.
				if( changeRow - nextBelow1 <= 0 && changeRow + nextBelow1 <= 11){
					
				}else{
					
					//print("<! Next Below !> " +  createField.theTileNames[ theRow, changeRow - nextBelow1 ] + "   " + createField.theField[ theRow, changeRow - nextBelow1 ] );
					
					//If the next position is empty we move below
					if( createField.theField[ theRow, changeRow - nextBelow1 ] == 0){
						
						
						//We need to check the cube that has been inputted and move it as a set.
						
						// 0. We check if next pos is available  [if empty]. If not we stop
						// 1. we check the current row. If it is not empty than we move the content to the empty position
						// 2.Then check the row that follows, if it is empty we do nothing. If it contains something we move it the current row.
						// 3. Then We check for the row again. Does it contain anything? If so we move it one square. If not we do nothing.
						
						
						 
						
						
						
						//Schema
						// [ +N,     Center,     -N  ]
						
						
						//The next takes the info of the current position
						createField.theField[ theRow, changeRow - nextBelow1 ] = createField.theField[ theRow, changeRow ];
						
						//print ("<Out Index>"   +  (changeRow-1 + nextBelow1)  + "   changeR: " + changeRow + "    nextBelow: " + nextBelow1);
						
						if(changeRow + (nextBelow1 +nextBelow1) < 12){
							
							
							//We delete the previous position
						createField.theField[ theRow, changeRow ] = createField.theField[ theRow, changeRow + nextBelow1] ;
							
							
							print ("We activate a trap card: " + createField.theTileNames[ theRow, changeRow + nextBelow1] + "    " + createField.theField[ theRow, changeRow + nextBelow1] );
							if(createField.theField[ theRow, changeRow ] == 0){
								createField.theField[ theRow, changeRow ] = createField.theField[ theRow, changeRow + nextBelow1] ;
							}
							//createField.theField[ theRow, changeRow ] = 0; //= createField.theField[ theRow, (changeRow + nextBelow1 )];
							
						}else{
							
							//If it is empty we get here. We delete the previous position an put nothing
							createField.theField[ theRow, changeRow ] = 0 ;
						}
						 
						
						
						//We delete the previous position
						//createField.theField[ theRow, changeRow ] = createField.theField[ theRow, changeRow + nextBelow1] ;
						
						//We Refresh the visuals
						connectToGameManager = GameObject.Find("gameManager");
						connectToGameManager.GetComponent<generateCube>().deleteAllCubes();
						connectToGameManager.GetComponent<generateCube>().generateField();
						
					}
					
				}
				
				
			}//End For
			
		}//End For	
		
		
		
		
		
		
		
		//print("***" + Random.Range(0,(createField.theField.Length-1)/10));
		
		//We change row while staying within the table's index.
		if(changeRow <= 0){
			
			//We reset the value
			changeRow = 10;
			
		}else{
 
			changeRow -= 1;
			
			//It calls itself again
	 		Invoke("moveBlocks", 3); 
		}
		
	
	}
	
	
	void importMapData(){
		
		//we get the map
		//this.GetComponent<createField>().initMe();
		/*GameObject theCreateField = new GameObject();
		theCreateField = GameObject.Find("gameManager");
		theCreateField.GetComponent<createField>().;*/
		//impTheField = createField.theField;
		
		print("++" + createField.theField.Length);
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	
	
}
