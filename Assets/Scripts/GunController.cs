using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] BulletController player;
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] AudioClip reloadAudioClip;
	[SerializeField] AudioClip bulletFireSound;
	[SerializeField] TargetController target;

	private Vector3 bulletHitPosition;
	private AudioSource AudioSource;
	private float bulletInterval;

	void Start(){
		bulletInterval = 0;
		AudioSource = gameObject.GetComponent<AudioSource> ();
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
					if (hit.collider.gameObject.GetComponent<TargetController>() != null) {
						print ("あああ");
						target.ShootTarget (hit);
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

	private void Reload(){
		player.bulletBoxCount -= (30 - player.bulletCount);
		player.bulletCount = 30;
		AudioSource.PlayOneShot (reloadAudioClip);
	}

}
