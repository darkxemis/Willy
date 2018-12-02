using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float MAXSPEED = 10f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;

	// Use this for initialization
	void Start () {
		this.rb2d = GetComponent<Rigidbody2D>();
		this.anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.anim.SetFloat("Speed", Mathf.Abs(this.rb2d.velocity.x));	
		this.anim.SetBool("Grounded", this.grounded);

		if (Input.GetKeyDown(KeyCode.Space) && this.grounded) {
			this.jump = true;
		}
	}

	void FixedUpdate() {
		/*1 o 0 dependiendo si vamos a la derecha o izquierda */
		float h = Input.GetAxis("Horizontal");

		this.rb2d.AddForce (Vector2.right * this.speed * h);

		/*Esto lo usamos para que no pueda correr más de un valor establecido*/
		float limitedSpeed = Mathf.Clamp(this.rb2d.velocity.x, -MAXSPEED, MAXSPEED);
		this.rb2d.velocity = new Vector2 (limitedSpeed, this.rb2d.velocity.y);

		/*Esto lo usamos para cambiar la imagen del personaje mriando izquierda o derecha*/
		if (h > 0.1f){
			transform.localScale = new Vector3(1f, 1f, 1f);
			Debug.Log (h);
		}

		if (h < -0.1f){
			transform.localScale = new Vector3(-1f, 1f, 1f);
			Debug.Log (h);
		}

		if(jump) {
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}
	}
}
