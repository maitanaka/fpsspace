using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] GameObject player;
	[SerializeField] AudioClip reloadAudioClip;
	[SerializeField] AudioClip bulletFireSound;

	private Vector3 bulletHitPosition;
	private AudioSource AudioSource;
	private float bulletInterval;
	private BulletController bulletController;

	void Start(){
		bulletInterval = 0;
		bulletController = player.GetComponent<BulletController> ();
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
				}
			}
		}

		if(Input.GetKey(KeyCode.R)){
			if (bulletController.bulletCount < 30) {
				Reload ();
				AudioSource.PlayOneShot (reloadAudioClip);
			}
		}
	}

	private void Shoot(RaycastHit hit){
		bulletInterval = 0.0f;
		bulletHitPosition = hit.point;
		GameObject BulletFire = Instantiate (bulletFire, bulletHitPosition, transform.rotation);
		AudioSource.PlayOneShot (bulletFireSound);
		bulletController.bulletCount -= 1;
		Destroy (BulletFire, 0.2f);
	}

	private void Reload(){
		bulletController.bulletBoxCount -= (30 - bulletController.bulletCount);
		bulletController.bulletCount = 30;
	}
}
