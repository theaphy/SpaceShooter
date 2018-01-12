using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour {

	public Rigidbody bossy;

	public GameObject shot;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartFlight() {
		InvokeRepeating("MoveBoss", 0.0f, 1.2f);
	}

	public void BossDead () {
		
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
			Mathf.Clamp (bossy.position.z, -13, 13 )
		);
		Debug.Log (bossy.position);

		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

	}

	void FixedUpdate () {
		
	}
}
