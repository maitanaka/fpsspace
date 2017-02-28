using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public int bulletCount;
	public int bulletBoxCount;

	// Use this for initialization
	void Start () {
		bulletCount = 30;
		bulletBoxCount = 150;
	}

	public void changeBulletCount(){
		bulletCount -= 1;
	}

	public void ChangeBulletBoxCount(){
		bulletBoxCount -= 1;
	}

	public void ReloadBullets(){
		bulletBoxCount -= (30 - bulletCount);
		bulletCount = 30;
	}
}
