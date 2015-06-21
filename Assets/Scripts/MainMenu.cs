using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool mainMenuOpen = true;
	public Animator menuAnim;
	public Animator charSelectAnim;
	public string levelName;

	public void StartGame (){
		Application.LoadLevel(levelName);
	}

	void Update () {
		if (Input.anyKeyDown && mainMenuOpen) {			
			mainMenuOpen = false;
			menuAnim.SetBool("MainMenu", false);
			charSelectAnim.SetBool("MainMenu", false);
		}
		if (Input.GetKeyDown (KeyCode.Escape) && !mainMenuOpen) {			
			mainMenuOpen = true;
			menuAnim.SetBool("MainMenu", true);
			charSelectAnim.SetBool("MainMenu", true);
		}
	}
}
