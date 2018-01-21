using UnityEngine;
using System.Collections;

public class titleAnimation : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		InvokeRepeating("runFlash",3,15);
	}
	
	// Update is called once per frame
	void  runFlash() {
		anim.SetTrigger("flash");
	}
}
