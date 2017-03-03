using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] BulletController player;
	[SerializeField] AudioClip reloadAudioClip;
	[SerializeField] AudioClip bulletFireSound;
	[SerializeField] TargetController target;
	[SerializeField] Transform headMarker;
	[SerializeField] int score;

	private Vector3 bulletHitPosition;
	private AudioSource AudioSource;
	private float bulletInterval;

	void Start(){
		bulletInterval = 0;
		AudioSource = gameObject.GetComponent<AudioSource> ();
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		bulletInterval += Time.deltaTime;
		if (Input.GetMouseButton (0)) {
			if (bulletInterval >= 0.2f) {
				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast (ray, out hit)) {
					Shoot (hit);
					if (hit.collider.name == "target") {
						ShootTarget (hit);
					}
				}
			}
		}

		if(Input.GetKey(KeyCode.R)){
			if (player.bulletCount < 30) {
				Reload ();
			}
		}
	}

	private void Shoot(RaycastHit hit){
		bulletInterval = 0.0f;
		bulletHitPosition = hit.point;
		GameObject BulletFire = Instantiate (bulletFire, bulletHitPosition, transform.rotation);
		AudioSource.PlayOneShot (bulletFireSound);
		player.bulletCount -= 1;
		Destroy (BulletFire, 0.2f);
	}

	private void ShootTarget(RaycastHit hit){
		float distance = Vector3.Distance(hit.point, headMarker.position);
		if (distance <= 0.1) {
			score += 5;
		} else {
			score += 2;
		}

		target.hp -= 1;

		if (target.hp == 0) {
			target.anim.SetBool ("broken", true);
			Invoke ("RecoverTarget", 5);
		}
	}

	private void Reload(){
		player.bulletBoxCount -= (30 - player.bulletCount);
		player.bulletCount = 30;
		AudioSource.PlayOneShot (reloadAudioClip);
	}

	private void RecoverTarget(){
		target.anim.SetBool ("broken", false);
		target.hp = 5;
	}
}
