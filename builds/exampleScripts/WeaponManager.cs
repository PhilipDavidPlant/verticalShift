using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	private int playerNum;
	RapidFireWeapon rapidWeapon;
	StandardWeapon stdWeapon;
	private bool isAlive;

	List<IFireable> currentWeaponArray = new List<IFireable>();
	int current;

	void OnEnable() {
		GetComponentInParent<DeathScript>().onDeath += setDeath;
		GetComponentInParent<DeathScript>().onRespawn += setRespawn;
		isAlive = true;
	}

	void OnDisable() {
		GetComponentInParent<DeathScript>().onDeath -= setDeath;
		GetComponentInParent<DeathScript>().onRespawn -= setRespawn;
	}

	void Start () {
		rapidWeapon = GetComponent<RapidFireWeapon>();
		stdWeapon = GetComponent<StandardWeapon>();
		currentWeaponArray.Add(stdWeapon);
		currentWeaponArray.Add(rapidWeapon);

		if (GetComponentInParent<shipAttributes> () != null) {
			playerNum = GetComponentInParent<shipAttributes>().playerNumber;
		} else {
			//playerNum = 0;
		}

		current = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive){
			if(Input.GetButtonDown("Fire" + playerNum)){
				currentWeaponArray[current].fireDown();
			}
		}
		if(Input.GetButtonUp("Fire" + playerNum)){
			currentWeaponArray[current].fireUp();
		}
		if (Input.GetKeyDown("w")) {
			current=1;
		}
		if (Input.GetKeyDown("s")) {
			current=0;
		}
	}

	void setDeath(){
		isAlive = false;
		currentWeaponArray[current].fireUp();
	}
	void setRespawn(){
		isAlive = true;
	}
}
