using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainController : MonoBehaviour {

	public static float freeSquareXCoord;
	public static float freeSquareYCoord;

	// Use this for initialization
	void Start () {
		UpdateFreeSquare();
		//MixChips (5);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameRules.startGame) {
			if (Input.GetMouseButtonDown(0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray,out hit)) {
					Debug.Log (hit.transform.name);
					if(hit.transform.name.Contains("Chip")){
						Debug.Log (freeSquareXCoord + " // "+ freeSquareYCoord);
						if((hit.transform.position.x==freeSquareXCoord || hit.transform.position.y==freeSquareYCoord)){
							if(Mathf.Abs(hit.transform.position.x-freeSquareXCoord)==1|| Mathf.Abs(hit.transform.position.y-freeSquareYCoord)==1){
								MoveChip(hit.transform,freeSquareXCoord,freeSquareYCoord);
							}
						}
					}
				}
				GameRules.currentChipArray=GameObject.FindGameObjectsWithTag("Chip");
				UpdateFreeSquare();
			}
		}
	}

	public static void UpdateFreeSquare () {
		Debug.Log ("Update Free Square");
		Transform[] squareArray = CreateStartScene.squareList.ToArray ();
		GameObject[] chipArray = CreateStartScene.chipList.ToArray ();
		bool[] isBusySquare = new bool[16];

		for (var i=0; i<squareArray.Length; i++) {
			for(var j=0;j<chipArray.Length;j++){
				if(squareArray[i].position.x==chipArray[j].transform.position.x
				   && squareArray[i].position.y==chipArray[j].transform.position.y){
					isBusySquare[i]=true;
				}
			}
		}
		for(var i=0;i<16;i++){
			if(isBusySquare[i]==false){
				freeSquareXCoord=squareArray[i].transform.position.x;
				freeSquareYCoord=squareArray[i].transform.position.y;
				Debug.Log ("Свободная клетка находится в коодринатах: х= "+freeSquareXCoord+ " у= " +freeSquareYCoord);
			}
		}
	}

	public void MixChips(int iterationsCount){
		List<GameObject> canMoveChipList = new List<GameObject> ();
		int iteration = 0;
		while (iteration < iterationsCount) {
			for (int i=0; i<CreateStartScene.chipList.Count; i++) {
				if ((CreateStartScene.chipList [i].transform.position.x == freeSquareXCoord || CreateStartScene.chipList [i].transform.position.y == freeSquareYCoord)) {
					if (Mathf.Abs (CreateStartScene.chipList [i].transform.position.x - freeSquareXCoord) == 1 || Mathf.Abs (CreateStartScene.chipList [i].transform.position.y - freeSquareYCoord) == 1) {
						canMoveChipList.Add (CreateStartScene.chipList [i]);
					}
				}
			}
			int index = UnityEngine.Random.Range (0, canMoveChipList.Count);
			Debug.Log ("Колличество элемнтов для движения: "+canMoveChipList.Count+" Передвигаемый элемент:  "+canMoveChipList [index].name+ " с координатами х= " +
			           canMoveChipList [index].transform.position.x +" у= "+canMoveChipList [index].transform.position.y+ 
			           "\n Двигаем его в клетку с координатами: х= "+freeSquareXCoord+" у= "+freeSquareYCoord);
			MoveChip (canMoveChipList [index].transform, freeSquareXCoord, freeSquareYCoord);
			UpdateFreeSquare();
			canMoveChipList.Clear();
			iteration++;
		}
		 
	}

	public static void MoveChip (Transform chipForMove, float targetXCoord, float targetYCoord) {
		Debug.Log ("Двигаем фишку");
		chipForMove.transform.position = new Vector3 (targetXCoord,targetYCoord,-0.2f);
	}
}
