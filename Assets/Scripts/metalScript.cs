using UnityEngine;
using System.Collections;

public class metalScript : MonoBehaviour {

	public int coolDown;
	bool isAlive;
	SpriteRenderer theSprite;
	AudioSource metalPickupSound;

	// Use this for initialization
	void Start () {
		isAlive = true;
		theSprite = GetComponent<SpriteRenderer>();
		metalPickupSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back * (Time.deltaTime * 10));
	}

	void OnTriggerEnter2D (Collider2D youHitMe){
		//Debug.Log("Tigger Fired!");
		if(isAlive){
			if(youHitMe.tag == "Player"){
				youHitMe.GetComponent<shipAttributes>().scrapMetal += 1;
				isAlive = false;
				theSprite.enabled = false;
				metalPickupSound.Play();
				StartCoroutine("countDown");
			}
		}
	}

	IEnumerator countDown(){
		int countDown = coolDown;
		while (countDown > 0) {
			yield return new WaitForSeconds(1);
			countDown--;
		}
		isAlive = true;
		theSprite.enabled = true;
	}

}
