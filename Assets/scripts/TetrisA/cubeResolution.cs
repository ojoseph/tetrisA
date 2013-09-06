using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class cubeResolution : MonoBehaviour {
	
	int prevCubeValue = 0;
	int currentCubeValue = 0;
	
	
	//Will hold in memory the cubes from the same color in that chain.
	List<string> memorizeCubesSet = new List<string>();
	
	public	List<string> memCubeCombi = new List<string>();
	
	
	//used to assign which direction we want to look at
	enum lookDirection{
		left,
		right,
		up,
		down 
	}
	
	
	public int cubeMemValue = 0;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Use this for initialization
	public void testFct() {
		
		//print ("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
		
	}
	
	
	
	public void resolve(){
		 
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0; theRow < theNumRows; theRow++){

			//We populate the rows
			for(int incre = 0; incre < 11 ; incre++){
				
				//print ("<TTT>       " + createField.theTileNames[theRow, incre] + "     " + createField.theField[theRow, incre]);
				
				//If the current array contains a cube we start the loop.
				if(createField.theField[theRow, incre] != 0){
					
 					//print ("<X> We start to look from here for similar cubes " + createField.theTileNames[theRow, incre] + "    " +  createField.theField[theRow, incre]  + " <X>");
					
					//We put the value of the cube in memory
					cubeMemValue = createField.theField[theRow, incre];
					
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
		
			theWantedDirection = lookDirection.right;
		
			switch(theWantedDirection){
				case lookDirection.right:
					//int nextCaseCheck  = theField[theRow,incre + 1];
					indexCaseCheckHorizontal = -1;
				break;
				case lookDirection.left:
					//int nextCaseCheck  = theField[theRow,incre - 1];
					indexCaseCheckHorizontal = +1;
				break;
				case lookDirection.up:
					//int nextCaseCheck  = theField[theRow,incre + 1];
					indexCaseCheckVertical = +1;
				break;
				case lookDirection.down:
					//int nextCaseCheck  = theField[theRow,incre - 1];
					indexCaseCheckVertical = -1;
				break;
			
			}
				
			
			/*int posTempVertical =  indexCaseCheckVertical;
			int posTempHorizontal = indexCaseCheckHorizontal;*/
			int theIncreV  = indexCaseCheckVertical;
			int theIncreH  = indexCaseCheckHorizontal;
		
			/*print ("INCREV " +theIncreV); //Why does this shows up as empty?
			print ("INCREH " +theIncreH);*/ //Why does this shows up as empty?
		
			int theNumRows = (createField.theField.Length/10); 
			for(int theRow = 0; theRow < theNumRows; theRow++){
	
				//We populate the rows
				for(int incre = 0; incre < 11; incre++){
					
					//We try to recover the location,
					if(createField.theTileNames[theRow, incre] == theCubeWeFound){
					
					
					
					
					
						//print("------- > " + (theRow + theIncreH));
						if((incre + theIncreH) >=0){
						
							//print("we start checking");
							if(createField.theField[theRow, incre  + theIncreH] != 0 ){
								//print("@@@@  " + createField.theTileNames[theRow, incre + theIncreH] + "     "+ createField.theField[theRow, incre + theIncreH]);
							
								//If the value of the cube is the same as the one in the memory than we add it to the colelction 
								if(createField.theField[theRow, incre + theIncreH]  == cubeMemValue){
									print("======================================================");
									print ("");
									//print("We got a combinaison  Next" + createField.theTileNames[theRow, incre + theIncreH] + "  " + createField.theField[theRow, incre + theIncreH] + "   Curr" + createField.theTileNames[theRow, incre] + "  " + createField.theField[theRow, incre]);
									print("We got a combinaison  " + "   Curr" + createField.theTileNames[theRow, incre] + "  " + createField.theField[theRow, incre] + "   Next" + createField.theTileNames[theRow, incre + theIncreH] + "  " + createField.theField[theRow, incre + theIncreH]);
									
									
									bool existOrNot = false;
									bool existOrNot2 = false;
								
									if(memCubeCombi.Count == 0){
										//We add the info in a temporary mem.
										memCubeCombi.Add(createField.theTileNames[theRow, incre]);
										memCubeCombi.Add(createField.theTileNames[theRow,  incre + theIncreH]);	
									}
								
									for(int h = 0; h <= memCubeCombi.Count-1; h++){
									
										
 
										print ("------  " + h + "  ------");
										//We remove the dupllications 
										if(memCubeCombi[h] == createField.theTileNames[theRow, incre]){
											existOrNot = true;
											//f it already exist we remove it.
											//memCubeCombi.Remove(createField.theTileNames[theRow, incre]);
											//memCubeCombi.RemoveAt(h);
											print("<REMOVE>  RemoveAt: " + memCubeCombi[h] );	
										}
									
										if(memCubeCombi[h] == createField.theTileNames[theRow, incre + theIncreH]){
											existOrNot2 = true;
											//f it already exist we remove it.
											//memCubeCombi.Remove(createField.theTileNames[theRow, incre]);
											//memCubeCombi.RemoveAt(h);
											print("<REMOVE>  RemoveAt: " + memCubeCombi[h] );	
										}
									
									
									
										if(h == memCubeCombi.Count-1){
											print("We LOOPED THROUGH THE WHOLE Curr Array" + h);
											
											if(existOrNot == true){
											
											}else{
												
												memCubeCombi.Add(createField.theTileNames[theRow, incre]);
											 
											}
										
											if(existOrNot2 == true){
											
											}else{
												 
												memCubeCombi.Add(createField.theTileNames[theRow,  incre + theIncreH]);	
											}
										
										}
									
										
										//print("<In memory>  We have this in memory: " + memCubeCombi[h] );	
									
									}
								
								
								
								
								//	memCubeCombi
								 	
									
								
									
								
									print ("");
									print("======================================================");
								}
						
							}
						
							
						
						
						
						}
						
						//We got the location so we move  in the direction previously dictated and try to find cubes or empty spaces within the arrays limits.
					
//						print( "|||||||||||||||||||||||| WE FOUND THE LOCATION |||||||||||||||||||||||   " + createField.theTileNames[theRow, incre]);
						
					
						
						
/*						print("----> " + theIncreV  + "   " + (theRow + theIncreV));
						print("----> " + theIncreH  + "   " + (incre + theIncreH));
						print ("====> " + createField.theTileNames[theRow, incre] + "  " +createField.theField[theRow, incre]);
					
*/						
					
						/*if(createField.theField[theRow + theIncreH, incre] != 0 ){
							print("@@@@  " + createField.theTileNames[theRow + theIncreH, incre] + "     "+ createField.theField[theRow + theIncreH, incre]);
							
							//If the value of the cube is the same as the one in the memory than we add it to the colelction 
							if(createField.theField[theRow + theIncreH, incre]  == cubeMemValue){
								print("======================================================");
								print ("");
								print("We got a combinaison  Next" +createField.theTileNames[theRow + theIncreH, incre] + "  " + createField.theField[theRow + theIncreH, incre] + "   Curr" + createField.theField[theRow, incre] + "  " + createField.theTileNames[theRow, incre]);
								print ("");
								print("======================================================");
							}
						
						}*/
					
					
						/*while( createField.theField[theRow + theIncreV, incre] != 0 && (theIncreV + theIncreV) >0 ){
							
							theIncreV += indexCaseCheckVertical;
							print("@@@@  " + createField.theTileNames[theRow + theIncreV, incre] + "     "+ createField.theField[theRow + theIncreV, incre]);
							
							if(theRow + theIncreV < 0){
								break;
							}
						
						}  */
					
					
					
						/*while(createField.theField[theRow + (theIncreV-1), incre + theIncreH] != 0 ){
							
							print( "<###  6  ###>" + createField.theTileNames[theRow, incre] + "       "  + createField.theField[theRow, incre] );
						
							//We restrain the search within the table's size
							 if(theIncreV < 10 && theIncreH <= 3){
							
								print( "<###  6  ###>" + createField.theTileNames[theRow, incre] + "       "  + createField.theField[theRow, incre] );
							
							}else{
							
								break;
							
							} 
						
						
							
							
							theIncreV += indexCaseCheckVertical;
							theIncreH += indexCaseCheckHorizontal;
						
						
							print("** "+ (theRow + theIncreV) + "     " + (incre + theIncreH) + " **");
							if((theRow + theIncreV) > 6){
								theIncreV = theIncreV-1;
								break;
							} 
							if( (incre + theIncreH) > 6){
								theIncreH = theIncreH-1;
								break;
							} 
						
						}  */
					
					
					
					}
				
				}
			
			}
		
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
	
		
		
	}
	
	
	
	
}
