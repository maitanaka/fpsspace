﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] GameObject bulletFire;
	[SerializeField] BulletController player;
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] TargetController target;
	[SerializeField] PlayerController playerController;

	private Vector3 bulletHitPosition;
	private AudioSource AudioSource;
	public AudioClip reloadAudioClip;
	public AudioClip bulletFireSound;

	void Start(){
		AudioSource = gameObject.GetComponent<AudioSource> ();
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

}
