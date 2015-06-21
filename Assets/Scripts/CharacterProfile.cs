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

	private Image charImage;

	public void CharacterSwitchLeft(){
		characterID -= 1;
	}
	public void CharacterSwitchRight(){
		characterID += 1;		
	}
	public void PlayerIsReady(bool playerBool){
		playerReady = playerBool;
	}

	void Start(){
		charImage = GetComponent<Image>();
	}

	void Update(){
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
			if (playerReady){
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
			if (playerReady){
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
			if (playerReady){
				profileBorder.color = colorMerle;
			} else {				
				profileBorder.color = colorDefault;
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
