using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if(!PlayerPrefs.HasKey("playerNumber")){
			PlayerPrefs.SetInt("playerNumber", 1);
		}
	}
}
