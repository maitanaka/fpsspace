using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject Bulletfire;
	[SerializeField] GameObject player;

	private Vector3 bulletHitPosition;
	private AudioSource audioSource;
	private AudioClip bulletFireSound;
	private GameObject bulletFire;
	private float bulletInterval;

	void Start(){
		bulletInterval = 0;
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
	}

	private void Shoot(RaycastHit hit){
		bulletInterval = 0.0f;
		BulletController bulletController = player.GetComponent<BulletController> ();
		bulletHitPosition = hit.point;
		bulletFire = Instantiate (Bulletfire, bulletHitPosition, transform.rotation);
		audioSource = bulletFire.GetComponent<AudioSource> ();
		bulletFireSound = audioSource.GetComponent<AudioClip> ();
		audioSource.PlayOneShot (bulletFireSound);
		bulletController.changeBulletCount ();
		Destroy (bulletFire, 0.1f);
	}
}
