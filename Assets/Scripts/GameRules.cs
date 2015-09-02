using UnityEngine;
using System.Collections;

public class GameRules : MonoBehaviour {

	public static bool startGame=false;
	public static float time=180.00f;
	public static GameObject[] currentChipArray;
	private bool showResult=false;

	// Update is called once per frame
	void Update () {
		if (startGame) {
			time-=Time.deltaTime;

			Debug.Log (time);
			if(time<=0){
				Debug.Log("It's FAIL! GAME OVER");
				Application.Quit();
			}
			for(int i=0;i<currentChipArray.Length;i++){
				Debug.Log("Фишка "+ currentChipArray[i].name + " \nКоординаты фишки: x= "+
				          currentChipArray[i].transform.position.x +" y= " +
				          currentChipArray[i].transform.position.y+"\nИзначальные координаты фишки: x= "+
				          CreateStartScene.startChipCoordArray[i].xCoordVal + 
				          " y= "+CreateStartScene.startChipCoordArray[i].yCoordVal
				          +" Номер "+i);
				if(currentChipArray[i].transform.position.x!=CreateStartScene.startChipCoordArray[i].xCoordVal ||
				   currentChipArray[i].transform.position.y!=CreateStartScene.startChipCoordArray[i].yCoordVal){
					Debug.Log("Последовательность разорвана!");
					break;
				}
				if(i==14){
					Debug.Log("Наконец то! У вас получилось!!");
					startGame = false;
					Debug.Log("Оставшееся время:" + time);
					showResult=true;
					time=0;
				}
			}
		}
	}

	public void OnButtonClick (){
		Debug.Log ("Игра началась!");
		startGame = true;
	}

	void OnGUI(){
		if (showResult == false) {
			GUI.Label (new Rect (Screen.width / 2 - 30, 130, 100, 30), "Time:" + time);
		}
		if (showResult) {
			GUI.Label (new Rect (Screen.width/2-70, 115, 150, 100), "Поздравляю с победой!! Нажмите на кнопку что бы завершить игру.");
		}
	}
}
