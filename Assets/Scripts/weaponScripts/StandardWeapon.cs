using UnityEngine;
using System.Collections;

public class StandardWeapon : MonoBehaviour, IFireable {
	bool isActive;
	string weaponName;
	public  Rigidbody2D projectile;
	public float bulletSpeed;
	AudioSource stdShootSound;

	void Awake(){
		isActive = true;
		stdShootSound = GetComponent<AudioSource>();
	}

	Vector3 previous;
	float velocity;
	
	void Update()
	{
		velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		previous = transform.position;
	}
	
	public void fireDown(){
		if(isActive){
			Rigidbody2D clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection((Vector2.up * bulletSpeed) + Vector2.up * velocity);
			stdShootSound.Play ();
			isActive = false;
		}
	}
	
	public void fireUp(){
		isActive = true;
	}
}
