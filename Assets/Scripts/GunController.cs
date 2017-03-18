using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] BulletController player;
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] TargetController target;
	[SerializeField] PlayerController playerController;
	[SerializeField] Camera camera;

	private Vector3 bulletHitPosition;
	private AudioSource AudioSource;
	private bool isSniping;
	public AudioClip reloadAudioClip;
	public AudioClip bulletFireSound;
	public GameObject snipe;

	void Start(){
		AudioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			Snipe ();
		}
	}


	public void Shoot(RaycastHit hit , Vector3 raydirection){
		playerController.bulletInterval = 0.0f;
		bulletHitPosition = hit.point;
		GameObject BulletFire = Instantiate (bulletFire, bulletHitPosition - raydirection, transform.rotation);
		AudioSource.PlayOneShot (bulletFireSound);
		player.bulletCount -= 1;
		Destroy (BulletFire, 0.2f);
	}

	public void Reload(){
		player.bulletBoxCount -= (30 - player.bulletCount);
		player.bulletCount = 30;
		AudioSource.PlayOneShot (reloadAudioClip);
	}

	private void Snipe(){
		if (isSniping) {
			snipe.SetActive (false);
			camera.fieldOfView = 60f;
			isSniping = false;
		} else {
			snipe.SetActive (true);
			camera.fieldOfView = 30f;
			isSniping = true;
		}
	}

}
