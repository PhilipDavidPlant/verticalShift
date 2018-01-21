using UnityEngine;
using System.Collections;

public class RapidFireWeapon : MonoBehaviour, IFireable {
	//===============================
	//========Class Variables========
	//===============================
	bool isActive;
	public float fireDelay;
	string weaponName;
	public  Rigidbody2D projectile;
	public float bulletSpeed;
	AudioSource stdShootSound;
	//===============================
	//======Class Constructors=======
	//===============================
	void Awake(){
		stdShootSound = GetComponent<AudioSource>();
		isActive = false;
		//fireDelay = 0.2f;
		weaponName = "RapidFire";
	}
	//===============================
	//========Class Functions========
	//===============================
	public void fireDown(){
		StartCoroutine("RapidWeaponCoroutine",fireDelay);
	}
	
	public void fireUp(){
		StopCoroutine("RapidWeaponCoroutine");
	}
	
	public string getName(){
		return weaponName;
	}
	//===============================
	//=======Class Enumerators=======
	//===============================
	IEnumerator RapidWeaponCoroutine(float fireDelay){
		while (true) {
			Rigidbody2D clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(Vector2.up* bulletSpeed);
			yield return new WaitForSeconds(fireDelay);
			stdShootSound.Play ();
		}
	}
}
