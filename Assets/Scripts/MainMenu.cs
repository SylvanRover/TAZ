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

	public void MainMenuClose(){
		mainMenuOpen = false;
		menuAnim.SetBool("MainMenu", false);
		charSelectAnim.SetBool("MainMenu", false);
	}
	public void MainMenuOpen(){
		mainMenuOpen = true;
		menuAnim.SetBool("MainMenu", true);
		charSelectAnim.SetBool("MainMenu", true);
	}

	void Update () {
		if (Input.GetButton ("Submit") && mainMenuOpen) {			
			MainMenuClose();
		}
	}
}