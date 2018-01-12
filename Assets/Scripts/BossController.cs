using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossController : MonoBehaviour {

	public Rigidbody bossy;
	public int shotCount;
	public GameObject explosion;
	public GameObject littleExplosion;

	private bool restart;
	private bool winner;

	public Text restartText;
	public Text winnerText;

	// Use this for initialization
	void Start () {
		restart = false;
		restartText.text = "";
		winnerText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene("Main");
			}
		}
	}

	public void StartFlight() {
		InvokeRepeating("MoveBoss", 0.0f, 1.2f);
	}

	public void MoveBoss () {
		bossy = GetComponent<Rigidbody>();

		float moveHorizontal = Random.Range(-1.0f, 1.0f);
		float moveVertical = Random.Range(-1.0f, 1.0f);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		bossy.velocity = movement * 3;


		bossy.position = new Vector3 (
			Mathf.Clamp (bossy.position.x, -6, 6),
			0.0f,
			Mathf.Clamp (bossy.position.z, -13, 12 )
		);
//		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);



	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Bolt" && shotCount < 3) {
			
			Instantiate(littleExplosion, other.transform.position, other.transform.rotation);
			shotCount++;

		} 
		if (other.tag == "Bolt" && shotCount == 3) {
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy (this);
			winnerText.text = "You Won!";
			restart = true;
			restartText.text = "Press 'R' for Restart";

		}
	}

	void FixedUpdate () {

		
	}
}
