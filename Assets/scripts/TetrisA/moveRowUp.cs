using UnityEngine;
using System.Collections;

public class moveRowUp : MonoBehaviour {

public string theRecovered;
public string cubeInMemoName;	
public int cubeInMemoVal;
public int zaRowNumber;
	
	void OnMouseDown(){
		print("GOOD LORD YOU HAVE CLICKED ME");
		
		// We recover the row
		theRecovered = this.gameObject.name.Replace("rowUpBtn","");
		this.gameObject.name = this.gameObject.name.Replace("rowUpBtn","");
			
		
		int theNumRows = (createField.theField.Length/10); 
		for(int theRow = 0; theRow < theNumRows; theRow++){
			for(int incre = 0; incre < 11 ; incre++){
				
//				print( createField.theTileNames[theRow, incre] + "  " + theRecovered);
				// If we find the location we start the process
				if(createField.theTileNames[theRow, incre] == theRecovered){
					
					// We save the info o the first position in the temp variable
					cubeInMemoName = createField.theTileNames[theRow, incre];
					cubeInMemoVal = createField.theField[theRow, incre];
					zaRowNumber = int.Parse(cubeInMemoName.Replace("A","")); 
					//print ("< EEEEE > OH OMG ROW NUMBER: " + zaRowNumber);
					
					
					
					// We lock th range  By transfering the value and ajusting the index
					int qSomeTheRow = zaRowNumber-1;
					 
					for(int qOtherTncre = 0; qOtherTncre < 7; qOtherTncre++){
						//print ("< M#9 > : " + createField.theTileNames[qOtherTncre, qSomeTheRow] + "   " + createField.theField[qOtherTncre, qSomeTheRow]+ "   " + createField.theTileNames[qOtherTncre+1, qSomeTheRow] );
						
						//We prevent it from getting out of index, we copy the info in th next cell.
						if(qOtherTncre+1 < 7){
							print ("< M#9 > : " + createField.theTileNames[qOtherTncre, qSomeTheRow] + "   <=  " + createField.theTileNames[qOtherTncre+1, qSomeTheRow]);
							//createField.theField[qOtherTncre, qSomeTheRow] = createField.theField[qOtherTncre+1, qSomeTheRow];
							
							//We transfer from one to the other.
							createField.theField[qOtherTncre, qSomeTheRow] = createField.theField[qOtherTncre + 1, qSomeTheRow];
							
							//We reached the last index, we transfer the tempValue and clear it
							if(qOtherTncre+1 == 6){
								
								//We found the last pos, lets transfer the data
								print("< !!! > Hey we reached the last " + createField.theTileNames[qOtherTncre + 1, qSomeTheRow]);
								createField.theField[qOtherTncre + 1, qSomeTheRow] = cubeInMemoVal;
								
							}
							
							
							
							//Once the movement done we should refresh the scen as right now it is called only on each cube movemet
							// <!> Please refresh the scene!
							
							
						}
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
