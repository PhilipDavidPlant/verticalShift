using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

	bool isActive;
	string weaponName;
	
	void Awake(){
		isActive = true;
		weaponName = "RocketLauncher";
	}
	
	public void fireDown(){
		if(isActive){
			Debug.Log("RocketFired");
			isActive = false;
		}
	}
	
	public void fireUp(){
		isActive = true;
	}
	
	public string getName(){
		return weaponName;
	}
}
