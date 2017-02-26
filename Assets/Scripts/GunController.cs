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
	private BulletController bulletController;

	void Start(){
		bulletInterval = 0;
		bulletController = player.GetComponent<BulletController> ();
		audioSource = bulletFire.GetComponent<AudioSource> ();
		bulletFireSound = audioSource.GetComponent<AudioClip> ();
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
		bulletHitPosition = hit.point;
		bulletFire = Instantiate (Bulletfire, bulletHitPosition, transform.rotation);
		audioSource.PlayOneShot (bulletFireSound);
		bulletController.changeBulletCount ();
		Destroy (bulletFire, 0.1f);
	}
}
