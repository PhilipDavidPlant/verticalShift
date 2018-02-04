using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameControllerScript : MonoBehaviour {
	
	public List<GameObject> players;
	public GameObject[] spawnPoints;
	
	public Sprite[] shipColours = new Sprite[4];
	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		InvokeRepeating("debouncedUpdate",0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void debouncedUpdate(){
		//checkPlayerScores();
	}

	void checkPlayerScores(){
		List<GameObject> playersWithAScore = new List<GameObject>();
		players.ForEach( (player)=> {
			if(player.GetComponent<ShipAttributes>().lives > 0){
				playersWithAScore.Add(player);
			}
		});

		if(playersWithAScore.Count == 1){
			Time.timeScale = 0;
			Debug.Log("player " + (playersWithAScore[0].GetComponent<ShipAttributes>().playerNumber+1) + " wins");
		}
	}
}
