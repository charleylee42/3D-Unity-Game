using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroManager : MonoBehaviour {

	public float speed; //visible in the scripts
	private Rigidbody rb;

	public Text resultText;
	public Text healthText;
	public Text scoreText;

	public int maxHealth = 3;
	private int health;

	public int maxScore;
	private int score;

	private bool isGrounded = false;
	public float jumpForce = 200;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		healthText.text = "Health: " + health;
		rb = GetComponent<Rigidbody> ();	//define rb to the sphere (referencing to the sphere)
		score = 0;
		maxScore = GameObject.FindGameObjectsWithTag("Item").Length; //length tells the number of the item
		scoreText.text = "Score: " + score + "/" + maxScore;
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal"); //input = the thing you control
		float moveVertical = Input.GetAxis("Vertical"); //give actual numbers

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); //3D force

		rb.AddForce (movement * speed);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGrounded) {
				isGrounded = false; //you can't jump if you don't touch the ground
				Debug.Log ("Jumped!");
				rb.AddForce (Vector3.up * jumpForce);
			}
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Platform")) { //tag objects platform for the player to jump on them
			Debug.Log("I hit the ground!");
			isGrounded = true;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Goal") {
			Debug.Log ("You reached the goal!");
			this.gameObject.SetActive (false);
			resultText.gameObject.SetActive (true);
			Invoke("NextLevel", 5.0f); //make the function happen but after a delay
		}
		if (other.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("You took damage!");
			//other.gameObject.SetActive(false); //turns game obj on and off (enemy disappears upon collision)

			health--;
			healthText.text = "Health: " + health;
			if (health <= 0) {
				//this.gameObject.SetActive (false); //this -> player's set off
				resultText.text = "GAME OVER";
				resultText.gameObject.SetActive (true);
				//ResetLevel ();
				Invoke("ResetLevel", 5.0f); //make the function happen but after a delay
			}
		}
	}
}
