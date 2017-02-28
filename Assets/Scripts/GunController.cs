using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] GameObject player;
	[SerializeField] AudioClip reloadAudioClip;

	private Vector3 bulletHitPosition;
	private AudioSource fireAudioSource;
	private AudioClip bulletFireSound;
	private AudioSource reloadAudioSource;
	private float bulletInterval;
	private BulletController bulletController;

	void Start(){
		bulletInterval = 0;
		bulletController = player.GetComponent<BulletController> ();
		fireAudioSource = bulletFire.GetComponent<AudioSource> ();
		bulletFireSound = fireAudioSource.GetComponent<AudioClip> ();
		reloadAudioSource = gameObject.GetComponent<AudioSource> ();
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
				bulletController.ReloadBullets ();
				reloadAudioSource.PlayOneShot (reloadAudioClip);
			}
		}
	}

	private void Shoot(RaycastHit hit){
		bulletInterval = 0.0f;
		bulletHitPosition = hit.point;
		GameObject BulletFire = Instantiate (bulletFire, bulletHitPosition, transform.rotation);
		fireAudioSource.PlayOneShot (bulletFireSound);
		bulletController.changeBulletCount ();
		Destroy (BulletFire, 0.2f);
	}
}
