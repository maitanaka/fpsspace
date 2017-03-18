using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] GunController gunController;
	[SerializeField] BulletController player;
	[SerializeField] TargetController target;
	[SerializeField] ScoreManager score;

	public float bulletInterval;

	// Use this for initialization
	void Start(){
		bulletInterval = 0;
		GameObject obj = GameObject.FindWithTag ("GameManager");
		GameManager gameManager = obj.GetComponent<GameManager> ();
		gameManager.bullet = player;
		score = gameManager.scoreManager;
		target = gameManager.target;
		gunController.snipe = gameManager.snipe;
	}

	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (transform.position, transform.forward);
		bulletInterval += Time.deltaTime;
		if (Input.GetKey (KeyCode.R)) {
			if (player.bulletCount < 30) {
				gunController.Reload ();
			}
		}
		if (!Input.GetMouseButton (0)) {
			return;
		}
		if (bulletInterval < 0.2f) {
			return;
		}

		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (player.bulletCount != 0) {
				Vector3 raydirection = ray.direction;
				gunController.Shoot (hit, raydirection);
				if (hit.collider.gameObject.GetComponent<TargetController> () != null) {
					target.ShootTarget (hit);
				}
			}
		}
	}
}
