using UnityEngine;
using System.Collections;

public class LevelSetup : MonoBehaviour {
	
	public GameObject cameraPrefab;
	public GameObject shipPrefab;
	public Canvas HUDPrefab;
	private SpawnManager spawnPoint;

	private gameControllerScript gameController;

	void Start() {
		spawnPoint = GetComponent<SpawnManager>();
		gameController = GetComponent<gameControllerScript>();
		//initialiseLevel(PlayerPrefs.GetInt("playerNumber"));
		initialiseLevel(3);
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
		int column = 0;
		int row = 1;

		for(int i=0; i < number; i++){
			GameObject newPlayer = createPlayer(i);
			gameController.players.Add(newPlayer);
			GameObject newCamera = createCamera(columns, rows, column, row, newPlayer);
			GameObject newHUD = createHUD(newPlayer.GetComponent<ShipAttributes>());
			newHUD.GetComponent<Canvas>().worldCamera = newCamera.GetComponent<Camera>();
			//newCamera.transform.position = newPlayer.transform.position + new Vector3(0,0,-1f);
			//newCamera.transform.parent = newPlayer.transform;
			// newCamera.GetComponent<CameraScript>().ship = newPlayer.transform;
			// newCamera.GetComponent<CameraScript>().enabled = true;	
			column++;
			if(column == columns){column = 0; row++;}
		}

	}

	GameObject createHUD(ShipAttributes shipAttributes){
		GameObject createdHUD =  new HUDFactory(shipAttributes).create(HUDPrefab.gameObject);
		return createdHUD;
	}

	GameObject createCamera(int totalColumns, int totalRows, int col, int rw, GameObject newPlayer){
		GameObject createdCamera =  new CameraFactory(totalColumns, totalRows, col, rw, newPlayer).create(cameraPrefab);
		return createdCamera;
	}

	GameObject createPlayer(int i){
		GameObject player =  new ShipFactory(i).create(shipPrefab, spawnPoint.spawnPoints[i].transform.position, transform.rotation);
		return player;
	}

}