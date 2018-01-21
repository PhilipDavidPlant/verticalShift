using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	public ParticleSystem explosion;
	private Rigidbody2D theRigidbody2D;
	private SpriteRenderer theSprite;
	private PolygonCollider2D theCollider;
	private AudioSource audio;
	private SpawnManager spawnPoint;
	private shipAttributes shipAttributes;

	public delegate void deathAction(); // Prototype function for the events fired by this script (toggle death and dieEvent)
	public event deathAction onDeath; // This event is used by the ship movement and weapon manager scripts to block controller input when a player dies.
	public event deathAction onRespawn;
	public static event deathAction dieEvent; // This event sends out to the player cameras. It is static so all cameras will receive the event when it is fired.
	
	void Start(){
		explosion.enableEmission = true;
		audio = explosion.GetComponent<AudioSource>();
		theRigidbody2D = GetComponent<Rigidbody2D>();
		theSprite = GetComponent<SpriteRenderer>();
		theCollider = GetComponent<PolygonCollider2D>();
		shipAttributes = GetComponentInParent<shipAttributes>();
		spawnPoint = GameObject.FindWithTag("GameController").GetComponent<SpawnManager>();

	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log("Hit");
			Die ();

	}
	public void Die (){
		theRigidbody2D.velocity = new Vector3(0,0,0);
		theRigidbody2D.angularVelocity = 0;
		theRigidbody2D.isKinematic  = true;
		if(!explosion.isPlaying){explosion.Play();}
		audio.Play();
		theSprite.enabled = false;
		theCollider.enabled = false;
		onDeath();
		dieEvent();
		StartCoroutine("countDownSpawn");


		//GameObject.Find("GameMaster").GetComponent<gameControllerScript>().playerScore -= 1;
	}

	IEnumerator countDownSpawn(){
		int countDown = 8;
		while (countDown > 0) {
			Debug.Log(countDown);
			yield return new WaitForSeconds(1);
			countDown--;
		}
		transform.position = spawnPoint.spawnPoints[shipAttributes.playerNumber].transform.position;
		theSprite.enabled = true;
		theCollider.enabled = true;
		theRigidbody2D.isKinematic  = false;
		onRespawn();
	}
}
