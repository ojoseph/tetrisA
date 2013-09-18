using UnityEngine;
using System.Collections;

public class moveRowUp : MonoBehaviour {

public string theRecovered;
public string cubeInMemoName;	
public int cubeInMemoVal;
public int zaRowNumber;

	
//Will contain the button name	
string theButtonName;
	
//Handles the direction	
int theMovement;
	
	
//GameObj that serves to acces the GameManager
GameObject connectToGameManager;	
	
	void OnMouseDown(){
		
		
		//We check on which elm this script is beign attached to.
		//From that we decide if its a up or a down
		
		//We trip up the content so that only the Letter is left
		theButtonName  = (this.gameObject.name.Substring(this.gameObject.name.Length-2)).Substring(0,1);
		//theButtonName = theButtonName.Substring(0,1);
		
		//We strip out the value and keep only the letter
		//theButtonName = theButtonName.Substring(1);
		print("<>  WHAT IS LEFT FROM WHAT HAS BEEN REMOVED!!!!! <> "  + theButtonName);
		
		// Depending on which button clicked we change the movement of the cubes.
		switch(theButtonName){
			case "A":
					theMovement = 1;
					print ("UP MOVEMENT " + theMovement);
				break;
			
			case "G":
					
					theMovement = -1;
					print ("DOWN MOVEMENT " + theMovement);
				break;
		}
		
		
		
		
		
		
		print("GOOD LORD YOU HAVE CLICKED ME " + theButtonName);
		
		// We recover the row
		theRecovered = this.gameObject.name.Substring(this.gameObject.name.Length-2); //this.gameObject.name.Replace("rowUpBtn","");
		this.gameObject.name = this.gameObject.name.Substring(this.gameObject.name.Length-2);
			
		
		
		
		
		
		
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0; theRow < theNumRows; theRow++){
			for(int incre = 0; incre < 11 ; incre++){
				
//				print( createField.theTileNames[theRow, incre] + "  " + theRecovered);
				// If we find the location we start the process
				if(createField.theTileNames[theRow, incre] == theRecovered){
					
//					print("G/////////////////RRERWERWE");
					switch(theButtonName){
						case "A":
							// We save the info o the first position in the temp variable
							cubeInMemoName = createField.theTileNames[theRow, incre];
							cubeInMemoVal = createField.theField[theRow, incre];
							zaRowNumber = int.Parse(cubeInMemoName.Replace("A","")); 
							//print ("< EEEEE > OH OMG ROW NUMBER: " + zaRowNumber);
						
						
						
						
						
						
							// We lock the range  By transfering the value and ajusting the index
							int qSomeTheRow = zaRowNumber -1;
							 
							for(int qOtherTncre = 0; qOtherTncre < 7; qOtherTncre++){
								//print ("< M#9 > : " + createField.theTileNames[qOtherTncre, qSomeTheRow] + "   " + createField.theField[qOtherTncre, qSomeTheRow]+ "   " + createField.theTileNames[qOtherTncre+1, qSomeTheRow] );
								
								//We prevent it from getting out of index, we copy the info in th next cell.
								if(qOtherTncre +1 < 7){
									print ("< M#9 > : " + createField.theTileNames[qOtherTncre, qSomeTheRow] + "   <=  " + createField.theTileNames[qOtherTncre +theMovement, qSomeTheRow]);
								 
									
									//We transfer from one to the other.
									createField.theField[qOtherTncre, qSomeTheRow] = createField.theField[qOtherTncre +theMovement, qSomeTheRow];
									
									//We reached the last index, we transfer the tempValue and clear it
									if(qOtherTncre +theMovement == 6){
										
										//We found the last pos, lets transfer the data
		//								print("< !!! > Hey we reached the last " + createField.theTileNames[qOtherTncre +1, qSomeTheRow]);
										createField.theField[qOtherTncre +theMovement, qSomeTheRow] = cubeInMemoVal;
										
									}
									
									
									
									//Once the movement done we should refresh the scen as right now it is called only on each cube movemet
									// <!> Please refresh the scene!
								
									GameObject.Find("gameManager").GetComponent<cubeResolution>().resolve();
								
									//We Refresh the visuals
									connectToGameManager = GameObject.Find("gameManager");
									connectToGameManager.GetComponent<generateCube>().deleteAllCubes();
									connectToGameManager.GetComponent<generateCube>().generateField();
									
								}
								
							}// End For
						
					
						
						
						
						break;
						case "G":
							// We save the info o the first position in the temp variable
							cubeInMemoName = createField.theTileNames[theRow, incre];
							cubeInMemoVal = createField.theField[theRow, incre];
							zaRowNumber = int.Parse(cubeInMemoName.Replace("G","")); 
//							print ("< GGGG > OH OMG ROW NUMBER: " + zaRowNumber);
						
						
						
						
						
							// We lock the range  By transfering the value and ajusting the index
							int vSomeTheRow = zaRowNumber -1; 
							 
							for(int qOtherTncre = 6; qOtherTncre > -1; qOtherTncre--){
							
//								print ("< M#9 > : " + createField.theTileNames[qOtherTncre, vSomeTheRow] + "   " + createField.theField[qOtherTncre, vSomeTheRow]); /* + "   " + createField.theTileNames[qOtherTncre -1, vSomeTheRow] );*/
								
								if(qOtherTncre -1 >-1){
//									print ("< R#P > : " + createField.theTileNames[qOtherTncre, vSomeTheRow] + "   <=  " + createField.theTileNames[qOtherTncre +theMovement, vSomeTheRow]);
									
									//We transfer from one to the other.
									createField.theField[qOtherTncre, vSomeTheRow] = createField.theField[qOtherTncre +theMovement, vSomeTheRow];
								
									//We reached the last index, we transfer the tempValue and clear it
									if(qOtherTncre -1 == 0){
										
										//We found the last pos, lets transfer the data
//										print("< !!! > Hey we reached the last " + createField.theTileNames[qOtherTncre +theMovement, vSomeTheRow]);
										createField.theField[qOtherTncre +theMovement, vSomeTheRow] = cubeInMemoVal;
										
									}
								
									//Once the movement done we should refresh the scen as right now it is called only on each cube movemet
									// <!> Please refresh the scene!
									
									GameObject.Find("gameManager").GetComponent<cubeResolution>().resolve();
								
									//We Refresh the visuals
									connectToGameManager = GameObject.Find("gameManager");
									connectToGameManager.GetComponent<generateCube>().deleteAllCubes();
									connectToGameManager.GetComponent<generateCube>().generateField();
								
								} 
			 
							}// End For
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						break;
					}
					
					
					
					
					
					
					
			 
					
					
					
					
					
					
					
					
					
				}//End If we find the cube 
				
				
				
				
			}
		}
		
		
		// On each click we move the cubes to the upper position
		
		
		
		// We relocate the position of the position √
		// We check all the items within the row. √
		// We save the highest position in a temporary  variable√
		// We move all the cube's position by 1     B => A     C => B    D => C   E => D   F => E  G => F√
		// Than we put the temporary data into the last position [G]      G =  temporaryVarValue (which held the value of A)√
		// We need to refresh the scene! Upon each click
		
		
	}
	
}
