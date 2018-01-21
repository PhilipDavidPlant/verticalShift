using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	
	public float playerSpeed;
	public float turnSpeed;
	public ParticleSystem exhaustEffect;
	private int playerNum;
	private bool isAlive;

	void OnEnable()
	{
		GetComponent<DeathScript>().onDeath += setDeath;
		GetComponent<DeathScript>().onRespawn += setRespawn;
		isAlive = true;
	}
	
	void OnDisable()
	{
		GetComponent<DeathScript>().onDeath -= setDeath;
		GetComponent<DeathScript>().onRespawn -= setRespawn;
	}

	void Start(){
		 playerNum = GetComponent<shipAttributes>().playerNumber;
		 //Debug.Log ("playerNum: " + playerNum);
		 exhaustEffect.enableEmission = true;
	}

	void setDeath(){
		isAlive = false;
	}

	void setRespawn(){
		isAlive = true;
	}
	
	void Update () {
		//Setting the rotation of the ship based on the input from the horizontal axis
		if(isAlive){
			transform.Rotate(0,0,Input.GetAxis("Horizontal" + playerNum)*-turnSpeed * Time.deltaTime);
			if(Input.GetButton("Thrust" + playerNum)){
				GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, playerSpeed * Time.deltaTime));
				if(!exhaustEffect.isPlaying){exhaustEffect.Play();}
			}
			else if(exhaustEffect.isPlaying){exhaustEffect.Stop();}

		}else if(exhaustEffect.isPlaying){exhaustEffect.Stop();}
	}
}
