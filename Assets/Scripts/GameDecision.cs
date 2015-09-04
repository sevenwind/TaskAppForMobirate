using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameDecision : MonoBehaviour {
	List<DecisonObjectLinks> chipsOutOfPlace = new List<DecisonObjectLinks>();

	public void CreateDecision(){
		for (int i=0; i<GameRules.currentChipArray.Length; i++) {
			if (GameRules.currentChipArray [i].transform.position.x != CreateStartScene.startChipCoordArray [i].xCoordVal ||
			    GameRules.currentChipArray [i].transform.position.y != CreateStartScene.startChipCoordArray [i].yCoordVal) {
				chipsOutOfPlace.Add(new DecisonObjectLinks(GameRules.currentChipArray [i].name,GameRules.currentChipArray [i].transform.position.x,
				                                           GameRules.currentChipArray [i].transform.position.y,GameRules.currentChipArray [i].transform.position.x,
				                                           GameRules.currentChipArray [i].transform.position.y));

			}
		}

		for (int rowCount=0; rowCount<4; rowCount++) {
			for (int elementNum=0; elementNum<4; elementNum++) {
				if (GameRules.currentChipArray [elementNum+rowCount*4].transform.position.x != CreateStartScene.startChipCoordArray [elementNum+rowCount*4].xCoordVal ||
				    GameRules.currentChipArray [elementNum+rowCount*4].transform.position.y != CreateStartScene.startChipCoordArray [elementNum+rowCount*4].yCoordVal) {
					//MainController.freeSquareXCoord,MainController.freeSquareYCoord

				}
			}
		}
	}
}

public class DecisonObjectLinks : MonoBehaviour{
	public string objectName;
	public float oldXCoordVal;
	public float oldYCoordVal;
	public float newXCoordVal;
	public float newYCoordVal;
	
	public DecisonObjectLinks(string chipName, float xOldValue, float yOldValue,float xNewValue, float yNewValue){
		objectName = chipName;
		oldXCoordVal = xOldValue;
		oldYCoordVal = yOldValue;
		newXCoordVal = xNewValue;
		newYCoordVal = yNewValue;
	}
}