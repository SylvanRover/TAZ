using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerID = 0;
	public bool controlsGamepad = false;
	public bool controlsTouch = true;
	public bool controlsMouse = true;
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

	public float speed;	
	private Vector3 target;

	private int direction;
	private float _posX;

	private Vector3 startPos;
	private Vector3 endPos;
	public float buffer = 1f;

    void Flip() {
		// Switch the way the player is labelled as facing
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
		rBody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();		
		target = transform.position;

		direction = 1;
		_posX = transform.position.x;

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

			/*if(PlayerPrefs.GetInt("P3 Character") == 0){
				spriteRenderer.sprite = characterSprite1;
			}
			if(PlayerPrefs.GetInt("P3 Character") == 1){
				spriteRenderer.sprite = characterSprite2;
			}
			if(PlayerPrefs.GetInt("P3 Character") == 2){
				spriteRenderer.sprite = characterSprite3;
			}*/
		}


	}
	
	// Update is called once per frame
	void Update () {

		// Iso Depth		
		zdepth = this.transform.position;
		zdepth.z = this.transform.position.y;
		this.transform.position = zdepth;

		// Gamepad Controls
		float moveY = Input.GetAxis (verticalAxis);
		float moveX = Input.GetAxis (horizontalAxis);

		if (controlsGamepad) {
			rBody2D.velocity = new Vector2 (moveY * maxSpeed, rBody2D.velocity.y);
			rBody2D.velocity = new Vector2 (moveX * maxSpeed, rBody2D.velocity.x);
		}

		// Touch Controls
		if (playerID == 0) {
			if (controlsTouch){
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began || Input.GetMouseButtonDown (0)) {
					//Debug.LogError ("Clicked on Position with mouse" + target);
					target = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
					target.z = transform.position.z;
				}
				transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
			}
			if (controlsMouse){
				// Mouse Controls
				startPos = transform.position;
				if (Input.GetMouseButton (0)) {
					//Debug.LogError ("Clicked on Position with mouse" + target);
					target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					target.z = transform.position.z;
				}
				transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
                /*endPos = target;
				if ( Mathf.Abs(startPos.x - endPos.x) <= buffer){
					target = transform.position;
				}*/
            }
        }

		// Flip sprite
		if (controlsMouse || controlsTouch) {
			if (transform.position.x > _posX && !facingRight) {
                Flip();
            } else if (transform.position.x < _posX && facingRight) {
                Flip();
            }		
			_posX = transform.position.x;
		}

		if (controlsGamepad) {
			float someScale = transform.localScale.x;
			if (moveX > 0 && !facingRight) {
				Flip ();            
			} else if (moveX < 0 && facingRight) {
				Flip (); 
			}
		}
	}
}
