using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotator : MonoBehaviour {

	private Rigidbody turret;
	
	public GameObject shot;
	public GameObject player;
	public Transform shotSpawn;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		turret = GetComponent<Rigidbody>();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		
		turret.rotation = Quaternion.LookRotation (player.transform.position - shotSpawn.position);
		if (gameController.hazardCount == 0) {	
			if (Time.time % 2 == 0) {
				Instantiate (shot, shotSpawn.position, Quaternion.LookRotation (player.transform.position - shotSpawn.position));
			}
		}
	}
}
