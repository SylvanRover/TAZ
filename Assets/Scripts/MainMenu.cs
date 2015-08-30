using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	public bool mainMenuOpen = true;
	public Animator menuAnim;
	public Animator charSelectAnim;
	public string levelName;

	public int P1_Character;
	public int P2_Character;
	public int P3_Character;	
	
	[System.Serializable]
	public class Player {
		public int playerID;
		public int characterID;
		public bool playerReady;
		public float health;
		public Sprite characterSprite;
	}

	public List<Player> playerData;

	void Awake(){
		// Player 1
		PlayerPrefs.SetInt ("P1 Character", P1_Character);
		PlayerPrefs.SetFloat ("P1 Health", P1_Character);

		// Player 2
		PlayerPrefs.SetInt ("P2 Character", P2_Character);
		PlayerPrefs.SetFloat ("P2 Health", P3_Character);

		// Player 3
		PlayerPrefs.SetInt ("P3 Character", P2_Character);
		PlayerPrefs.SetFloat ("P3 Health", P3_Character);
	}

	IEnumerator FadeToStart() {
		yield return new WaitForSeconds(1);
		Application.LoadLevel(levelName);
	}

	public void StartGame (){
		StartCoroutine(FadeToStart());
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
		/*if (Input.GetButtonUp("Submit") && mainMenuOpen) {			
			MainMenuClose();
		}*/

		//Touch myTouch = Input.GetTouch(0);
		
		//Touch[] myTouches = Input.touches;
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			if (mainMenuOpen) {
				MainMenuClose();
				StartGame();
			}
		}

		if (Input.GetMouseButtonDown (0) || Input.GetButtonUp ("Submit")) {
			if (mainMenuOpen) {
				MainMenuClose();
				StartGame();
			}
		}
	}
}














