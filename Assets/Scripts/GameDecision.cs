using UnityEngine;
using System.Collections;

public class GameDecision : MonoBehaviour {


	public void CreateDecision(){

		for (int i=0; i<8; i++) {
			if(GameRules.currentChipArray[i].transform.position.x!=CreateStartScene.startChipCoordArray[i].xCoordVal ||
			   GameRules.currentChipArray[i].transform.position.y!=CreateStartScene.startChipCoordArray[i].yCoordVal){
				
			}
		}
	}
}
