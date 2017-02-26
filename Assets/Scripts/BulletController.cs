using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	[SerializeField] int bulletCount;
	[SerializeField] int bulletBoxCount;


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
}
