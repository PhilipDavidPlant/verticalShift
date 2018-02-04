using UnityEngine;
using System.Collections;

public class ShipAttributes : MonoBehaviour {

	public delegate void attributeAction(string WeaponType); 
	public delegate void onAttributeChange();
	public event attributeAction BuyPrimaryWeapon;
	public event onAttributeChange attributeChanged;

	public int playerNumber;
	private int _lives;
	public int lives {
		get { return _lives; }
		set { _lives = value; callAttributeChanged();}
	}
	private int _scrapMetal;
	public int scrapMetal{
		get { return  _scrapMetal; }
		set {  _scrapMetal = value; callAttributeChanged(); }
	}
	public int primaryWeaponPrice;
	public int secondaryWeaponPrice;

	void Start(){
		lives = 10;
		scrapMetal = 0;
		if (GameObject.Find ("GameController") != null) {
			GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<LevelAttributes>().shipColour [playerNumber];
		} else {
			playerNumber = 0;
		}
	}

	void callAttributeChanged(){
		if(attributeChanged != null){
			attributeChanged();
		}
	}
}
