using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPoints;
	
	// Use this for initialization
	void Awake () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
	}

}
