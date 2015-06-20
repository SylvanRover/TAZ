using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool mainMenuOpen = true;
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && mainMenuOpen) {			
			mainMenuOpen = false;
		}
	}
}
