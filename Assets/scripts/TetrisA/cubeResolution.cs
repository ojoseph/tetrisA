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
					
					print("=>: "  +  createField.theTileNames[theRow, incre] + "    " + createField.theField[theRow, incre]);	
					
					//We put the value of the cube in memory
					cubeMemValue = createField.theField[theRow, incre];
					
					//We call the function with the coordinates of the cube we found.
					lookForMatches(createField.theTileNames[theRow, incre], createField.theField[theRow, incre]);
					
					
					
					
					
					
					//We recover the location in the table and send it to the function
					
					//We need to loop in 4 directions, Up  Down  Left  Right. 
					//On each directions we move a square at the time and look for several info.
					//	First one we check if the next case is not out of the array index
					//	We check if the next position is no empty, if so we stop our research.
					//	We check if the the cube is the same color as the one that triggered this loop. If not we stop it right away. 
					//	For each block that matches the initial block's color, we add its info in a table 
					//		We repeat the process for the other directions.
					
					
					
				}else{
					print("<!!!  We bumbped into a empty spot   !!!>");
					//We break upon empty space
					break;
				}
				
				
				
				
			}
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	//void lookForAvailable(lookDirection theWantedDirection ,int theRow, int incre, int firstTkenLocation){
	void lookForMatches( string theCubeWeFound, int theCubeWeFoundValue){
		
			int indexCaseCheckHorizontal = 0;
			int indexCaseCheckVertical = 0;
			
			//We declare it before use
			lookDirection theWantedDirection;
		
			theWantedDirection = lookDirection.left;
		
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
					
					
						print ("THE CUBE FOUND: " + theCubeWeFound);
						
					
						
						for(int r = 0; r< 3; r++){
							
							//print("&&&" + createField.theTileNames[theRow, incre+ r] + "&&&");
							
						}
						
					
						int dummyIncre = 0;
						while(createField.theField[theRow, incre+ dummyIncre] != 0){
							
							
							print ("<#> " + createField.theTileNames[theRow, incre+ dummyIncre] + "   " + createField.theField[theRow, incre+ dummyIncre] +" <#>");
							dummyIncre+= indexCaseCheckHorizontal; // +1 to the left  <-
							
							//If we reach an empty space we break out
							if(createField.theField[theRow, incre+ dummyIncre] == 0){
								print ("<!> We encountered and empty space the value of Dummy is: " + dummyIncre);
								print ("");
								break;
							}
							
							//If the cube is not the same as first cube we found.
							if(createField.theField[theRow, incre+ dummyIncre] != theCubeWeFoundValue){
								
							}
						
						}
					
					
					
					
					
					
					
					
						//print("------- > " + (theRow + theIncreH));
						//Prevents from getting out og the index
						if((incre + theIncreH) >= 0){
						
							 
						
							//We check if the next position is not empty.
							if(createField.theField[theRow, incre  + theIncreH] != 0 ){
								//print("@@@@  " + createField.theTileNames[theRow, incre + theIncreH] + "     "+ createField.theField[theRow, incre + theIncreH]);
							
							//print("SSSSSSSSSSSSSSSSSSSS " + createField.theTileNames[theRow, incre + theIncreH]  + "   " + createField.theField[theRow, incre + theIncreH] );
							
								//If the value of the cube is the same as the one in the memory than we add it to the collection 
								if(createField.theField[theRow, incre + theIncreH]  == cubeMemValue){
									
									
								
									//print("vvvvvvvvvvvvvv  " + createField.theTileNames[theRow, incre + theIncreH]  + "   " + createField.theField[theRow, incre + theIncreH] );
									
								
								
								
									//theIncreH -= indexCaseCheckHorizontal;
									//print("########+++++++++  " + (theIncreH + indexCaseCheckHorizontal) );
									/*print("$$%$%$%%$$&$%#$%&#$  " + (incre + theIncreH) );
									print("EEEEEEEEEEEE  " +  incre );
									print("vvvvvvvvvvvvvv  " + createField.theTileNames[theRow, incre]  + "   " + createField.theField[theRow, incre] );
									print("$$%$%$%%$$&$%#$%&#$  " + (incre) );
									print("++++++++++++++  " + createField.theTileNames[theRow, incre + theIncreH]  + "   " + createField.theField[theRow, incre + theIncreH] );*/
									
									//We check if we are within the index range
									if((incre + theIncreH) >= 0){
										
										//We move one more
										while( createField.theField[theRow, incre + theIncreH]  ==  cubeMemValue){
											loopingPoints += 1;
											memCubeCombi.Add(createField.theTileNames[theRow, incre + theIncreH]);
											//print ("We are looping: " + createField.theTileNames[theRow, incre + theIncreH] +  "    " + createField.theField[theRow, incre + theIncreH]  +"  memCube:" + cubeMemValue);
											
											//If we get out we break this
											if((incre + theIncreH) <= 0){
												loopingPoints +=1;
												memCubeCombi.Add(createField.theTileNames[theRow, incre + theIncreH]);
												//print ("We are looping ZERO : " + createField.theTileNames[theRow, incre + theIncreH] +  "    " + createField.theField[theRow, incre + theIncreH]);
												
												//print ("AccumulatedPoints: " + loopingPoints);
												//If we find more than 3 cubes of the same set we add the last cube.
												if(loopingPoints >= 3){
													
													//We copy the data in the final table
													finalMemCubeCombi = memCubeCombi;
												
													//we clear the table
													//memCubeCombi.Clear();
												}else{
													//memCubeCombi.Clear();
												}
												loopingPoints = 0;
												break;
											}
											theIncreH += indexCaseCheckHorizontal;
												//print ("We are looping AFTER : " + createField.theTileNames[theRow, incre + theIncreH] +  "    " + createField.theField[theRow, incre + theIncreH]);
										}
									
									}
									
									
								
								
						
									
									 
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
						
						} */
					
					
						/*while( createField.theField[theRow + theIncreV, incre] != 0 && (theIncreV + theIncreV) >0 ){
							
							theIncreV += indexCaseCheckVertical;
							print("@@@@  " + createField.theTileNames[theRow + theIncreV, incre] + "     "+ createField.theField[theRow + theIncreV, incre]);
							
							if(theRow + theIncreV < 0){
								break;
							}
						
						}   */
					
					
					
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
						
						}   */
					
					
					
					}
				
				}
			
			}
		
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
	
		
		
	}
	
	
	
	
}

