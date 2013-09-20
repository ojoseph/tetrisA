using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class cubeResolution : MonoBehaviour {
	
	int prevCubeValue = 0;
	int currentCubeValue = 0;
	
	
	//Will hold in memory the cubes from the same color in that chain.
	List<string> memorizeCubesSet = new List<string>();
	
	public	List<string> memCubeCombi = new List<string>();
	public	List<string> finalMemCubeCombi = new List<string>();
	
	public	List<string> memCubeCombiOther = new List<string>();
	public	List<string> finalMemCubeCombiOther = new List<string>();
	
	
	//used to assign which direction we want to look at
	enum lookDirection{
		left,
		right,
		up,
		down 
	}
	
	
	public int cubeMemValue = 0;
	public int nbOfCubCombi = 0;
	public int loopingPoints = 0;
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
					
					//print("=>: "  +  createField.theTileNames[theRow, incre] + "    " + createField.theField[theRow, incre]);	
					
					//We put the value of the cube in memory
					cubeMemValue = createField.theField[theRow, incre];
					
					//We call the function with the coordinates of the cube we found.
					lookForMatches(createField.theTileNames[theRow, incre], createField.theField[theRow, incre], lookDirection.left);
				 
					
					
					//StartCoroutine(lookForMatches(createField.theTileNames[theRow, incre], createField.theField[theRow, incre], lookDirection.right));
					 
					
					
					
					
					//We recover the location in the table and send it to the function
					
					//We need to loop in 4 directions, Up  Down  Left  Right. 
					//On each directions we move a square at the time and look for several info.
					//	First one we check if the next case is not out of the array index
					//	We check if the next position is no empty, if so we stop our research.
					//	We check if the the cube is the same color as the one that triggered this loop. If not we stop it right away. 
					//	For each block that matches the initial block's color, we add its info in a table 
					//		We repeat the process for the other directions.
					
					
					
				}else{
//					print("<!!!  We bumbped into a empty spot   !!!>");
					//We break upon empty space
					break;
				}
				
				
				
				
			}
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	//void lookForAvailable(lookDirection theWantedDirection ,int theRow, int incre, int firstTkenLocation){
	void lookForMatches( string theCubeWeFound, int theCubeWeFoundValue, lookDirection decidedDir){
	//IEnumerator lookForMatches( string theCubeWeFound, int theCubeWeFoundValue, lookDirection decidedDir){
		
			int indexCaseCheckHorizontal = 0;
			int indexCaseCheckVertical = 0;
			
			//We declare it before use
			lookDirection theWantedDirection;
		
			//theWantedDirection = lookDirection.left;
			//theWantedDirection = decidedDir;
		
			theWantedDirection = lookDirection.up;
		
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
				
				//print("##################");	
			
				//We populate the rows
				for(int incre = 0; incre < 11; incre++){
					
					//We try to recover the location,
					if(createField.theTileNames[theRow, incre] == theCubeWeFound){
 						
						print ("  ");
						print ("  ");
						print ("  ");
						print ("THE CUBE FOUND: " + theCubeWeFound  + " " + theCubeWeFoundValue );
					
					
 						memCubeCombi.Clear();
					
					
					
					
					
						//------------START LINE RESOLUTION					
						///////
					
							//int dummyIncre = 0;
						int matchCounter = 0;
					
						// <  Left and Right > We look through  the items with a forward movement.
						//while( createField.theField[theRow, incre+ dummyIncre] != 0 ){
						for(int dummyIncre = 0; dummyIncre < 11; dummyIncre ++ ){
			 				
//							print("|||==========|||  " + createField.theTileNames[theRow, incre+ dummyIncre] + "       " + createField.theField[theRow, incre+ dummyIncre]);
							
						
							/*if( createField.theField[theRow, incre + dummyIncre] == 0){
								print ("<Q> LOG OUT <Q>");
								break;
							}  */
						
							//Add each value in the 
//							print ("<!> Check Dummy:" + dummyIncre + "  " +createField.theTileNames[theRow, incre + dummyIncre]);
							//memCubeCombi.Add( createField.theTileNames[theRow, incre + dummyIncre]);
//							print("We are adding:" + createField.theTileNames[theRow, incre + dummyIncre] + "    "  + createField.theField[theRow, incre + dummyIncre] );
							
							 
						
						
							//print(" Table lenght: " + memCubeCombi.Count);	
							
						
							// < !!! > This one goes from  right to left and gathers the cube all together
							if(createField.theField[theRow, incre + dummyIncre] != theCubeWeFoundValue){
// 								print ("<!> Not same Leave:" + dummyIncre);
								
								//We check which cubes are getting deleted.
								foreach (string tempItem in memCubeCombi){
//									print ("---- > " + tempItem);
								}
								
								//------------------------------------------------------------------------------------
							
							
//								print ("<P> We are now starting the deleting process:  " + matchCounter );
								if( /* dummyIncre >= 3 */   matchCounter >=3  ){
		 
	//								print ("<!-!> OK We Copy to Final: " + dummyIncre + "Started with: " + theCubeWeFound + ":  " + theCubeWeFoundValue);
	//								
	//								print(" Table lenght: " + memCubeCombi.Count);
									finalMemCubeCombi = memCubeCombi;
								
									//We can try here to delete the unrelated cubes.
									
									for( int t = 0; t < memCubeCombi.Count; t++){
									 //if(memCubeCombi[t] == createField.theTileNames
										//for(int search = 0; search < createField.theTileNames.Length; search++){
										
										
										
											//Loop until we recover the position of the current index [t]
											int someNumRows = (createField.theField.Length/10); 
											for(int someTheRow = 0; someTheRow < theNumRows; someTheRow++){
												for(int someIncre = 0; someIncre < 11; someIncre++){
													
													//We check if the position held by the table matches the index in the loop. If so we delete the info from the main table.
													if(memCubeCombi[t] == createField.theTileNames[someTheRow,someIncre]){
														
														//The data value held i the temp table has been recovered.
	//													print ("<!> ==>   We delete the data at position   <== <!>" + createField.theTileNames[someTheRow,someIncre]+ "  " + createField.theField[someTheRow,someIncre]);
												
														//We delete the information contained in the real table
														createField.theField[someTheRow,someIncre] = 0;
												
														// <note>The system automatically handles the vitual update.
												
														//We Contact the scoreManager and update the score upon each cube delete.
														scoreManager theActualScore = GetComponent<scoreManager>();
														//theActualScore.scoreValue +=1;
														theActualScore.raiseScore();
												
												
														
													}//End If
											
											
												}//End for
											}//EndFor
							 
									}//End For
								
								
									//Small For each that check the output
									foreach (string tempItem in memCubeCombi){
										print ("==> " + tempItem);
									}
									//memCubeCombi.Clear();
									break;
								}
							
							
								//------------------------------------------------------------------------------------
							
							
								memCubeCombi.Clear();
								//dummyIncre = 0;
								break;
							
							}else{
							
								//We add the cube in the temporary memory.
								memCubeCombi.Add( createField.theTileNames[theRow, incre + dummyIncre]);
								//Raise the number of match
								matchCounter += 1;
							
							}
						
							
							//dummyIncre+= indexCaseCheckHorizontal; // +1 to the left  <-
							
								
//							print ("<CHECK> value of dummy " + dummyIncre + "  " + createField.theTileNames[theRow, incre + dummyIncre] + "  " + createField.theField[theRow, incre + dummyIncre] );
						
							if(createField.theField[theRow, incre + dummyIncre] == 0){
							
//								print (" <&&&&> OMG!!!!!!  " + createField.theTileNames[theRow, incre + dummyIncre]);
//							
							}
							
						}
					
					
					
//						print(" < VVVVVVVVVVVVV > Process should be done in here    < VVVVVVVVVVVVV >");
					
						//*****************************************
					
						////////
						//------------END LINE RESOLUTION
					
						
						
						
						
						
						
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						//yield return new WaitForSeconds(0);
						
						
						
						
						
						
						
						//******
						//      FROM   TOP TO BOTTOM DETECTION
						//Will make the same thing as the previous one but taht will take care of gathering the cubes from bottom to top
						
						//int dummyIncre = 0;
						int matchCounter2 = 0;
					
						// <  Left and Right > We look through  the items with a forward movement.
						//while( createField.theField[theRow, incre+ dummyIncre] != 0 ){
						for(int dummyIncreUp = 0; dummyIncreUp < 7; dummyIncreUp ++ ){
					 		
						
						
						
							/*print("AAAAA " + ( theRow + dummyIncreUp) );
							print("The Row " +  theRow );
							print("The dummyIncre " + dummyIncreUp);*/
							print("|||==========|||  " + createField.theTileNames[ dummyIncreUp, incre] + "       " + createField.theField[ dummyIncreUp, incre]);
							//print("|||  NEXT BELOW  |||  " + createField.theTileNames[ dummyIncreUp, incre] + "       " + createField.theField[ dummyIncreUp, incre]); 
							
							//We check if the next item is the same as the  cube we found.
							if(createField.theField[ dummyIncreUp, incre] != theCubeWeFoundValue){
								
								//We check which cubes are getting deleted.
								foreach (string tempItemOther in memCubeCombiOther){
									print ("---- > " + tempItemOther );
								}
							
									if( /* dummyIncre >= 3 */   matchCounter2 >=3  ){
								
										finalMemCubeCombiOther = memCubeCombiOther;
								
										for( int t = 0; t < memCubeCombiOther.Count; t++){
											
											
									
											
									
									
									
											//Loop until we recover the position of the current index [t]
											int someNumRowsOther = (createField.theField.Length/10); 
											for(int someTheRowOther = 0; someTheRowOther < theNumRows; someTheRowOther++){
												for(int someIncre = 0; someIncre < 11; someIncre++){
													
													//We check if the position held by the table matches the index in the loop. If so we delete the info from the main table.
													if(memCubeCombiOther[t] == createField.theTileNames[someTheRowOther, someIncre]){
														
														//The data value held i the temp table has been recovered.
	 													print ("<!> ==>   We delete the data at position   <== <!>" + createField.theTileNames[someTheRowOther, someIncre]+ "  " + createField.theField[someTheRowOther, someIncre]);
												
														//We delete the information contained in the real table
														createField.theField[someTheRowOther,someIncre] = 0;
												
														// <note>The system automatically handles the vitual update.
												
														//We Contact the scoreManager and update the score upon each cube delete.
														scoreManager theActualScore = GetComponent<scoreManager>();
														//theActualScore.scoreValue +=1;
														theActualScore.raiseScore();
												
												
														
													}//End If
											
											
												}//End for
											}//EndFor
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
									
										}//End For
											
										
								
										//Small For each that check the output
										foreach (string tempItemOther in memCubeCombiOther){
											print ("==> " + tempItemOther);
										}
										//memCubeCombi.Clear();
										break;
								
								
								
									}
							
								memCubeCombiOther.Clear();
								//dummyIncre = 0;
								break;
							
							}else{
							
								//We add the cube in the temporary memory.
								print ("< ### > What is being saved in the memory !!!! " + createField.theTileNames[ dummyIncreUp, incre ] );
								memCubeCombiOther.Add( createField.theTileNames[ dummyIncreUp, incre] );
								//Raise the number of match
								matchCounter2 += 1;
							
							}
						 
						
						
						 
							
							
							
							
						
						
						
						
						
						
						
						
						
						
						//	print("|||==========|||  " + createField.theTileNames[theRow + dummyIncreUp, incre] + "       " + createField.theField[theRow + dummyIncreUp, incre]);
							
							/*print("+++++++");
							print("Dummy " + dummyIncreUp);
							print("Incre+Row " + (incre+ theRow));
							print("Incre " +  incre);
							print("+++++++");*/
						
						
						
							if( (incre + theRow) < 7 ){
//								print("|||==========|||  " + createField.theTileNames[incre+ theRow, dummyIncreUp] + "       " + createField.theField[incre+ theRow, dummyIncreUp]);
							}
						
						
						
						}
						
						
						print("       " );
						print("       " );
						print("       " );
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						   
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
							
							
							
							 
						
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
						//*****************************************
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					
					 
				 
					
					
					}
				
				}
			
			}
		
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
	
		
		
	}
	
	
	
	
}

