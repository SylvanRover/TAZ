using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerID = 0;
	public bool controlsGamepad = false;
	public float maxSpeed = 0.25f;

	private bool facingRight = true;
	private Animator anim;
	private Vector3 zdepth;
	private Rigidbody2D rBody2D;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rBody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Iso Depth		
		zdepth = this.transform.position;
		zdepth.z = this.transform.position.y;
		this.transform.position = zdepth;

		if (playerID != 0) {
			float moveY = Input.GetAxis ("Vertical");
			float moveX = Input.GetAxis ("Horizontal");

			rBody2D.velocity = new Vector2 (moveY * maxSpeed, rBody2D.velocity.y);
			rBody2D.velocity = new Vector2 (moveX * maxSpeed, rBody2D.velocity.x);
		}

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
