using UnityEngine;
using System.Collections;

public class PlayerSetup : MonoBehaviour {

	public GameObject[] cameras;
	public GameObject theObject;
	private int numPlayers = PlayerPrefs.GetInt("playerNumber");
	private shipAttributes attributes;

	void Start ()
	{
		GameObject clone;
		cameras = GameObject.FindGameObjectsWithTag("Camera");

		for(int i=0; i < numPlayers; i++ )
		{
			clone = Instantiate(theObject, transform.position + new Vector3(0,i*2,0), transform.rotation) as GameObject;
			attributes = clone.GetComponent<shipAttributes>();
			attributes.playerNumber = i;
//			cameras[i].GetComponent<Transform>().position = clone.transform.postion;
//			cameras[i].GetComponent<Transform>().parent = clone;

		}
	}
}
