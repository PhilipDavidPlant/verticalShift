using UnityEngine;
using System.Collections;

public class shipAttributes : MonoBehaviour {

	public delegate void attributeAction(string WeaponType); 
	public event attributeAction BuyPrimaryWeapon;

	public int playerNumber;
	public int lives;
	public int scrapMetal;
	public int primaryWeaponPrice;
	public int secondaryWeaponPrice;

	void Start(){
		if (GameObject.Find ("GameController") != null) {
						GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("GameController").GetComponent<LevelAttributes> ().shipColour [playerNumber];
		} else {
			playerNumber = 0;
		}
	}
}
