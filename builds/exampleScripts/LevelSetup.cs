using UnityEngine;
using System.Collections;

public class LevelSetup : MonoBehaviour {
	
	public GameObject cameraIn;
	public GameObject playerIn;
	public Canvas HUDIn;
	private SpawnManager spawnPoint;

	void Start() {
		spawnPoint = GetComponent<SpawnManager>();
		//initialiseLevel(PlayerPrefs.GetInt("playerNumber"));
		initialiseLevel(1);
	}
	// Function that divides up the screen for each players piece :: input paramater is the number of players
	void initialiseLevel(int number){
		
		int rows = 1;
		int columns = 1;
		
		switch (number){
			case 1:
				rows = 1;
				columns = 1;
				break;
			case 2:
				rows = 1;
				columns = 2;
				break;
			case 3:
				rows = 1;
				columns = 3;
				break;
			case 4:
				rows = 2;
				columns = 2;
				break;
			case 5:
				rows = 2;
				columns = 3;
				break;
			case 6:
				rows = 2;
				columns = 3;
				break;
			case 7:
				rows = 2;
				columns = 4;
				break;
			case 8:
				rows = 2;
				columns = 4;
				break;
			default:
				Debug.LogError("initialiseLevel only accepts inputs 1-8");
				return;
		}

		//Below is for calculating the size and position of each camera based on the rows and columns and then creating them
		int col = 0;
		int rw = 1;

		for(int i=0; i < number; i++){
			GameObject newPlayer = createPlayer(i);
			GameObject newCamera = createCamera(columns, rows, col, rw);
			Canvas newHUD = createHUD(i);
			newHUD.worldCamera = newCamera.GetComponent<Camera>();
			newCamera.transform.position = newPlayer.transform.position + new Vector3(0,0,-1f);
			//newCamera.transform.parent = newPlayer.transform;
			newCamera.GetComponent<CameraScript>().ship = newPlayer.transform;
			newCamera.GetComponent<CameraScript>().enabled = true;	
			col++;
			if(col == columns){col = 0; rw++;}
		}

	}

	Canvas createHUD(int i){
		Canvas HUD;
		HUD = Instantiate(HUDIn) as Canvas;
		HUD.GetComponent<HUDManager>().playerNumber = i;
		return HUD;
	}

	GameObject createCamera(int columns, int rows, int col, int rw){
		GameObject createdCamera = Instantiate(cameraIn) as GameObject;
		createdCamera.GetComponent<Camera>().rect = new Rect((1f/columns)*col, 1-((1f/rows)*rw), 1f/columns, 1f/rows);
		createdCamera.tag = "Camera";
		return createdCamera;
	}

	GameObject createPlayer(int i){
		GameObject clone;
		//Debug.Log (i);
		clone = Instantiate(playerIn, spawnPoint.spawnPoints[i].transform.position , transform.rotation) as GameObject; 
		shipAttributes attributes = clone.GetComponent<shipAttributes>();
		attributes.playerNumber = i;
		return clone;
	}

}


/* GLOSSARY
 * 
		int rows;
		if(number == 1){rows = 1;}
		else if(number % 3 == 0){rows = number/3;}
		else if((number-1) % 3 == 0){rows = (number-1)/3+1;}
		else{rows = (number/3)+1;}
		
		int columns;
		if(number%3 == 0){columns = 3;}
		else{columns = (number%3);}
		
		Debug.Log(rows + " , " + columns);
		
		for(int i=0; i < number; i++){
			GameObject createdCamera = Instantiate(cameraIn) as GameObject;
			Debug.Log(i+1);
			createdCamera.GetComponent<Camera>().rect = new Rect( ((1f/columns)*(i+1f))-(1f/columns), 0, 1f/columns, 1f/rows);
		}
 *
 */