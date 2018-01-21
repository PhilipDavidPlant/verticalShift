using UnityEngine;
using System.Collections;

public class gameControllerScript : MonoBehaviour {
	
	public int playerScore;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// Game Over Conditions
	if(playerScore == 0){
	Debug.Log("Game Over Bitches");
	}
	}
}
