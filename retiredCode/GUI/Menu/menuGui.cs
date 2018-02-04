using UnityEngine;
using System.Collections;

public class menuGui : MonoBehaviour {

	//private int selectedToolbar = 0;
	//private string[] toolbarStrings = {"One", "Two", "Three", "Four"};
	
		//if (GUI.Button (new Rect ((Screen.width/2),(Screen.height/2),80,20), "Start")) {
		//	Application.LoadLevel (1);
		//}

		// Determine which button is active, whether it was clicked this frame or not
		//selectedToolbar = GUI.Toolbar (new Rect ((Screen.width/2)-60,(Screen.height/2-50), 200, 30), selectedToolbar, toolbarStrings);
		
		// If the user clicked a new Toolbar button this frame, we'll process their input
		//if (GUI.changed)
		//{
		//	Debug.Log("The toolbar was clicked value: " + selectedToolbar);
		//	PlayerPrefs.SetInt("playerNumber", (selectedToolbar + 1));
		//}
	
	public void ExitGame(){
		Application.Quit();
		Debug.Log ("I quit");
	}
}

