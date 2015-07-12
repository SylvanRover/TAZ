using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterProfile : MonoBehaviour {

	public int playerID = 0;
	public int characterID = 0;
	public int characterMax = 2;
	public bool playerReady = false;
	public Text playerTitle;
	public Text characterName;
	public Image playerArrow;
	public Image profileBorder;
	public Sprite characterMagnus;
	public Sprite characterTaako;
	public Sprite characterMerle;
	public Color colorMagnus;
	public Color colorTaako;
	public Color colorMerle;
	public Color colorDefault;
	public Text playerNumber;

	public CharacterProfile player1;
	public CharacterProfile player2;
	public CharacterProfile player3;

	public MainMenu mainMenu;

	private Image charImage;
	private bool axisNavR = false;
	private bool axisNavL = false;

	private string horizontalAxis;
	private string verticalAxis;
	private string joystickA;
	private string joystickB;

	public void CharacterSwitchLeft(){
		if (!playerReady) {
			characterID -= 1;
		}

		// Player 1
		if (playerID == 0){
			if (player3.playerReady && characterID == player3.characterID) {
				characterID -= 1;	
			}
			if (player2.playerReady && characterID == player2.characterID) {
				characterID -= 1;	
			}
		}
		
		// Player 2
		if (playerID == 1){
			if (player1.playerReady && characterID == player1.characterID) {
				characterID -= 1;	
			}
			if (player3.playerReady && characterID == player3.characterID) {
				characterID -= 1;	
			}
		}
		
		// Player 3
		if (playerID == 2){
			if (player2.playerReady && characterID == player2.characterID) {
				characterID -= 1;	
			}
			if (player1.playerReady && characterID == player1.characterID) {
				characterID -= 1;	
			}
		}
		
		if (characterID < 0) {
			characterID = characterMax;
		}
		if (characterID > characterMax) {
			characterID = 0;
		}
	}
	public void CharacterSwitchRight(){
		if (!playerReady) {
			characterID += 1;
		}
		// Player 1
		if (playerID == 0){
			if (player2.playerReady && characterID == player2.characterID) {
				characterID += 1;	
			}
			if (player3.playerReady && characterID == player3.characterID) {
				characterID += 1;	
			}
		}

		// Player 2
		if (playerID == 1){
			if (player3.playerReady && characterID == player3.characterID) {
				characterID += 1;	
			}
			if (player1.playerReady && characterID == player1.characterID) {
				characterID += 1;	
			}
		}

		// Player 3
		if (playerID == 2){
			if (player1.playerReady && characterID == player1.characterID) {
				characterID += 1;	
			}
			if (player2.playerReady && characterID == player2.characterID) {
				characterID += 1;	
			}
		}
		
		if (characterID < 0) {
			characterID = characterMax;
		}
		if (characterID > characterMax) {
			characterID = 0;
		}
	}
	public void PlayerIsReady(bool playerBool){
		playerReady = playerBool;

		if (playerBool == true) {
			if (playerID == 0) {
				if (characterID == player2.characterID) {
					player2.CharacterSwitchRight ();
					if (player2.characterID == player3.characterID){
						player2.CharacterSwitchRight ();
					}
				}
				if (characterID == player3.characterID) {
					player3.CharacterSwitchRight ();
					if (player3.characterID == player2.characterID){
						player3.CharacterSwitchRight ();
					}
				}
				Debug.LogError(playerID + " is ready");
			}
			if (playerID == 1) {
				if (characterID == player1.characterID) {
					player1.CharacterSwitchRight ();
					if (player1.characterID == player3.characterID){
						player1.CharacterSwitchRight ();
					}
				}
				if (characterID == player3.characterID) {
					player3.CharacterSwitchRight ();
					if (player3.characterID == player1.characterID){
						player3.CharacterSwitchRight ();
					}
				}
				Debug.LogError(playerID + " is ready");
			}
			if (playerID == 2) {
				if (characterID == player2.characterID) {
					player2.CharacterSwitchRight ();
					if (player2.characterID == player1.characterID){
						player2.CharacterSwitchRight ();
					}
				}
				if (characterID == player1.characterID) {
					player1.CharacterSwitchRight ();
					if (player1.characterID == player2.characterID){
						player1.CharacterSwitchRight ();
					}
				}
				Debug.LogError(playerID + " is ready");
			}
		}
	}

	public void SetCharacters(){

	}

	void Start(){


		charImage = GetComponent<Image>();

		if (playerID == 0) {
			horizontalAxis = "Horizontal_P1";
			verticalAxis = "Vertical_P1";
			joystickA = "A_P1";
			joystickB = "B_P1";
		}
		if (playerID == 1) {
			horizontalAxis = "Horizontal_P2";
			verticalAxis = "Vertical_P2";
			joystickA = "A_P2";
			joystickB = "B_P2";
		}
		if (playerID == 2) {
			horizontalAxis = "Horizontal_P3";
			verticalAxis = "Vertical_P3";
			joystickA = "A_P3";
			joystickB = "B_P3";
		}
	}

	void AxisNavRight(){
		if (axisNavR){
			if (playerID == 0 && (!player2.playerReady || !player3.playerReady)){
				CharacterSwitchRight();
			}
			if (playerID == 1 && (!player3.playerReady || !player1.playerReady)){
				CharacterSwitchRight();
			}
			if (playerID == 2 && (!player1.playerReady || !player2.playerReady)){
				CharacterSwitchRight();
			}
		}
	}
	void AxisNavLeft(){
		if (axisNavL){
			if (playerID == 0 && (!player2.playerReady || !player3.playerReady)){
				CharacterSwitchLeft();
			}
			if (playerID == 1 && (!player3.playerReady || !player1.playerReady)){
				CharacterSwitchLeft();
			}
			if (playerID == 2 && (!player1.playerReady || !player2.playerReady)){
				CharacterSwitchLeft();
			}
		}
	}

	void Update(){
		bool wait = false;

		if (!mainMenu.mainMenuOpen) {

			//Switch Character with Gamepad
			if (Input.GetAxis (horizontalAxis) > 0.1) {
				AxisNavRight ();
				axisNavR = false;
			}
			if (Input.GetAxis (horizontalAxis) < 0.1 && Input.GetAxis (horizontalAxis) >= 0) {
				axisNavR = true;
			}
			if (Input.GetAxis (horizontalAxis) < -0.1) {
				AxisNavLeft ();
				axisNavL = false;
			}
			if (Input.GetAxis (horizontalAxis) > -0.1 && Input.GetAxis (horizontalAxis) <= 0) {
				axisNavL = true;
			}

			//Player is Ready
			if (!wait && !playerReady && Input.GetButtonDown (joystickA)) {
				wait = true;
				PlayerIsReady(true);
			}
			if (!wait && playerReady && Input.GetButtonDown (joystickB)) {
				PlayerIsReady(false);
				wait = true;
			}
			if (!wait && !playerReady && Input.GetButtonDown (joystickB)) {
				mainMenu.MainMenuOpen ();
				wait = true;
			}

			//Start Game
			if (!wait && playerReady && Input.GetButtonDown (joystickA)){
				/*foreach(MainMenu.Player p in mainMenu.playerData){
					if (!playerReady){
						PlayerIsReady(true);
					}
				}*/

				PlayerPrefs.SetInt ("P1 Character", player1.characterID);
				PlayerPrefs.SetInt ("P2 Character", player2.characterID);
				PlayerPrefs.SetInt ("P3 Character", player3.characterID);

				mainMenu.StartGame();
			}

			//Character IDs
			if (characterID < 0) {
				characterID = characterMax;
			}
			if (characterID > characterMax) {
				characterID = 0;
			}
			if (characterID == 0) {
				charImage.sprite = characterMagnus;
				playerTitle.color = colorMagnus;
				playerArrow.color = colorMagnus;
				characterName.text = "Magnus \n Burnsides";
				characterName.color = colorMagnus;
				if (playerReady) {
					profileBorder.color = colorMagnus;
				} else {				
					profileBorder.color = colorDefault;
				}
			}
			if (characterID == 1) {
				charImage.sprite = characterTaako;
				playerTitle.color = colorTaako;
				playerArrow.color = colorTaako;
				characterName.text = "Taako";
				characterName.color = colorTaako;
				if (playerReady) {
					profileBorder.color = colorTaako;
				} else {				
					profileBorder.color = colorDefault;
				}
			}
			if (characterID == 2) {
				charImage.sprite = characterMerle;
				playerTitle.color = colorMerle;
				playerArrow.color = colorMerle;
				characterName.text = "Merle \n HighChurch";
				characterName.color = colorMerle;
				if (playerReady) {
					profileBorder.color = colorMerle;
				} else {				
					profileBorder.color = colorDefault;
				}
			}
		}

		// Player Number
		if (playerID == 0) {
			playerNumber.text = "P1";
		} else {
			playerNumber.text = "CPU";
		}
	}
}
