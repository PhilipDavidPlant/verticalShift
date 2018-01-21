using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform ship;
	public float offset;
	private float shakeAmount;
	private float shakeFalloff;

	void OnEnable()
	{
		DeathScript.dieEvent += triggerShake;	
	}

	void OnDisable()
	{
		DeathScript.dieEvent -= triggerShake;
	}

	// Use this for initialization
	void Start () {
		//shakeFalloff = shakeAmount/10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = (ship.position - new Vector3(0, 0, offset)) + (Random.insideUnitSphere * shakeAmount);
		if(shakeAmount != 0){
			shakeAmount -= shakeFalloff;
		}
	}

	void triggerShake(){ //From ship death script
		//Debug.Log("shake");
		StartCoroutine("WaitForExplosionCoroutine");
	}


	IEnumerator WaitForExplosionCoroutine(){
			yield return new WaitForSeconds(0.1f);
			shakeAmount = 0.3f;
			shakeFalloff = shakeAmount/10;
	}

}




