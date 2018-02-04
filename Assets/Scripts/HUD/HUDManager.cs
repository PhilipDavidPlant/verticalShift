using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	public ShipAttributes shipAttributesReference;

	private Text[] HUDElements;
	private Text livesText;
	private Text scrapMetalText;

	void OnEnable(){
		shipAttributesReference.attributeChanged +=	updateHud;
		HUDElements = GetComponentsInChildren<Text>();
	 	foreach (var element in HUDElements)
		 {
			if (element.CompareTag("HUDLives") ) {
				livesText = element;
			}else if ( element.CompareTag("HUDMetal") ) {
				scrapMetalText = element;
			}	 
		 }
	}

	// Use this for initialization
	void Start () {
	}

	void updateHud(){
		livesText.text =  "Lives: " + shipAttributesReference.lives;
		scrapMetalText.text = "Scrap Metal: " + shipAttributesReference.scrapMetal;
	}

}
