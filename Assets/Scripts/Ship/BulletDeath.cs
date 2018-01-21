using UnityEngine;
using System.Collections;

public class BulletDeath : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col) {
		
			//Under: really ineffcient redo if possible
//			if(col.gameObject.GetComponent<DeathScript>() != null){
//				col.gameObject.GetComponent<DeathScript>().Die();
//			}
		Destroy(gameObject);
	}
}
