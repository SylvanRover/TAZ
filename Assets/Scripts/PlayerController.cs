using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerID = 0;
	public bool controlsGamepad = false;
	public float maxSpeed = 0.25f;
	private SpriteRenderer spriteRenderer;
	
	public Sprite characterSprite1;
	public Sprite characterSprite2;
	public Sprite characterSprite3;


	private bool facingRight = true;
	private Animator anim;
	private Vector3 zdepth;
	private Rigidbody2D rBody2D;

	private string horizontalAxis = "Horizontal_P1";
	private string verticalAxis = "Vertical_P1";
	private string joystickA = "A_P1";
	private string joystickB = "B_P1";

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rBody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (playerID == 0) {
			horizontalAxis = "Horizontal_P1";
			verticalAxis = "Vertical_P1";
			joystickA = "A_P1";
			joystickB = "B_P1";
			
			if(PlayerPrefs.GetInt("P1 Character") == 0){
				spriteRenderer.sprite = characterSprite1;
			}
			if(PlayerPrefs.GetInt("P1 Character") == 1){
				spriteRenderer.sprite = characterSprite2;
			}
			if(PlayerPrefs.GetInt("P1 Character") == 2){
				spriteRenderer.sprite = characterSprite3;
			}
		}
		if (playerID == 1) {
			horizontalAxis = "Horizontal_P2";
			verticalAxis = "Vertical_P2";
			joystickA = "A_P2";
			joystickB = "B_P2";

			if(PlayerPrefs.GetInt("P2 Character") == 0){
				spriteRenderer.sprite = characterSprite1;
			}
			if(PlayerPrefs.GetInt("P2 Character") == 1){
				spriteRenderer.sprite = characterSprite2;
			}
			if(PlayerPrefs.GetInt("P2 Character") == 2){
				spriteRenderer.sprite = characterSprite3;
			}
		}
		if (playerID == 2) {
			horizontalAxis = "Horizontal_P3";
			verticalAxis = "Vertical_P3";
			joystickA = "A_P3";
			joystickB = "B_P3";

			if(PlayerPrefs.GetInt("P3 Character") == 0){
				spriteRenderer.sprite = characterSprite1;
			}
			if(PlayerPrefs.GetInt("P3 Character") == 1){
				spriteRenderer.sprite = characterSprite2;
			}
			if(PlayerPrefs.GetInt("P3 Character") == 2){
				spriteRenderer.sprite = characterSprite3;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Iso Depth		
		zdepth = this.transform.position;
		zdepth.z = this.transform.position.y;
		this.transform.position = zdepth;

		float moveY = Input.GetAxis (verticalAxis);
		float moveX = Input.GetAxis (horizontalAxis);

		rBody2D.velocity = new Vector2 (moveY * maxSpeed, rBody2D.velocity.y);
		rBody2D.velocity = new Vector2 (moveX * maxSpeed, rBody2D.velocity.x);

		/* Keyboard Controls
		if (playerID != 0 && !controlsGamepad) {
			if (Input.GetKey(KeyCode.UpArrow)){
				Vector3 position = this.transform.position;
				position.y += speed;
				this.transform.position = position;
			}
			if (Input.GetKey(KeyCode.LeftArrow)){				
				Vector3 position = this.transform.position;
				position.x -= speed;
				this.transform.position = position;

			}
			if (Input.GetKey(KeyCode.DownArrow)){
				Vector3 position = this.transform.position;
				position.y -= speed;
				this.transform.position = position;
			}
			if (Input.GetKey(KeyCode.RightArrow)){
				Vector3 position = this.transform.position;
				position.x += speed;
				this.transform.position = position;
			}
		}*/
	
	}
}
