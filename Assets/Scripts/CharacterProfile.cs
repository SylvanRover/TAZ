using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterProfile : MonoBehaviour {

	public int profileID = 0;
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
	}
	public void CharacterSwitchRight(){
		if (!playerReady) {
			characterID += 1;		
		}
	}
	public void PlayerIsReady(bool playerBool){
		playerReady = playerBool;
	}

	void Start(){
		charImage = GetComponent<Image>();

		if (profileID == 0) {
			horizontalAxis = "Horizontal_P1";
			verticalAxis = "Vertical_P1";
			joystickA = "A_P1";
			joystickB = "B_P1";
		}
		if (profileID == 1) {
			horizontalAxis = "Horizontal_P2";
			verticalAxis = "Vertical_P2";
			joystickA = "A_P2";
			joystickB = "B_P2";
		}
		if (profileID == 2) {
			horizontalAxis = "Horizontal_P3";
			verticalAxis = "Vertical_P3";
			joystickA = "A_P3";
			joystickB = "B_P3";
		}
	}

	void AxisNavRight(){
		if (axisNavR){
			CharacterSwitchRight();
		}
	}
	void AxisNavLeft(){
		if (axisNavL){
			CharacterSwitchLeft();
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
			if (!wait && !playerReady && Input.GetButton (joystickA)) {
				playerReady = true;
				wait = true;
				Debug.LogError("Player " + profileID + " Pressed " + joystickA);
			}
			if (!wait && playerReady && Input.GetButton (joystickB)) {
				playerReady = false;
				wait = true;
				Debug.LogError("Player " + profileID + " Pressed " + joystickB);
			}
			if (!wait && !playerReady && Input.GetButton (joystickB)) {
				mainMenu.MainMenuOpen ();
				wait = true;
				Debug.LogError("Player " + profileID + " Pressed " + joystickB);
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
		if (profileID == 0) {
			playerNumber.text = "P1";
		} else {
			playerNumber.text = "CPU";
		}
	}

}
