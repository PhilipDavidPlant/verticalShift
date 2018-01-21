using UnityEngine;
using System.Collections;

public class ShipShoot : MonoBehaviour {
	
	public delegate void FireAction();
	public static event FireAction Fire;
	
	public  Rigidbody projectile;
	private int playerNum;

	void Start(){
		if (GetComponent<shipAttributes> () != null) {
			playerNum = GetComponent<shipAttributes> ().playerNumber;
		} else {
			playerNum = 0;
		}
	}

	void FixedUpdate () {

			if(Input.GetButton("Fire" + playerNum)){
				if(Fire != null){
					Fire();
				}
			}
			if(Input.GetButtonDown("Fire" + playerNum)){
				if(Fire != null){
					Fire();
				}
			}

//		if(Input.GetButtonDown("Fire" + playerNumber)){
//		Rigidbody clone;
//	    clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
//	    clone.velocity = transform.TransformDirection(Vector3.up * 100);;
		
	}
	
}


//projectileScript = gun.GetComponent<ProjectileScript>(); //this is how you did find "GameObject.Find("Gun")"