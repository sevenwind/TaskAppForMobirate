using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class CreateStartScene : MonoBehaviour {

	public Transform squarePrefab;
	public GameObject chipPrefab;

	public static List<Transform> squareList = new List<Transform> ();
	public static List<GameObject> chipList = new List<GameObject> ();
	//public static List<ObjectCoords> startChipList=new List<ObjectCoords> ();
	public static ObjectCoords[] startChipCoordArray=new ObjectCoords[]{
					new ObjectCoords(0,3),new ObjectCoords(1,3),new ObjectCoords(2,3),new ObjectCoords(3,3),
					new ObjectCoords(0,2),new ObjectCoords(1,2),new ObjectCoords(2,2),new ObjectCoords(3,2),
					new ObjectCoords(0,1),new ObjectCoords(1,1),new ObjectCoords(2,1),new ObjectCoords(3,1),
					new ObjectCoords(0,0),new ObjectCoords(1,0),new ObjectCoords(2,0)};

	private int materialNumber=1;

	void Awake(){
		for (var i = 0; i < 4; i++) {
			for (var j = 0; j < 4; j++) {
				Transform tempSquare=squarePrefab;
				tempSquare.name="Square"+i+j;
				Instantiate(tempSquare, new Vector3 (i, j, 0), Quaternion.identity);
				squareList.Add(GameObject.Find(tempSquare.name+"(Clone)").transform);
			}
		}
		for (var i = 3; i >= 0; i--) {
			for (var j = 0; j < 4; j++) {
				if(materialNumber==16){
					break;
				}
				Material currentMat = Resources.Load ("Materials/" + materialNumber.ToString ()) as Material;
				chipPrefab.name = "Chip" + materialNumber;
				chipPrefab.GetComponent<Renderer> ().material = currentMat;
				Instantiate (chipPrefab, new Vector3 (j, i, -0.2f), Quaternion.identity);
				chipList.Add (GameObject.Find(chipPrefab.name+"(Clone)"));
				materialNumber++;
			}
		}
		GameRules.currentChipArray=GameObject.FindGameObjectsWithTag("Chip");
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
