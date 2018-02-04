using UnityEngine;
using System.Collections;

public class LevelUI : MonoBehaviour {
	
public GUISkin inGameUI;
//public Font uiFont;
int score;
	
void OnGUI () {
		score = GameObject.Find("GameMaster").GetComponent<gameControllerScript>().playerScore;
		GUI.skin = inGameUI;
		//GUI.skin.font = uiFont;
		GUI.Label (new Rect (25, 25, 200, 30), "Lives: " + score.ToString());
		if(GameObject.Find("GameMaster").GetComponent<gameControllerScript>().playerScore == 0){
			GUI.Label (new Rect (Screen.width/2-80, Screen.height/2, 200, 30), "Game Over");
		}
		
	}
	
}
