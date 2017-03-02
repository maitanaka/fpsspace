using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public int hp;
	private Animator anim;

	// Use this for initialization
	void Start () {
		hp = 5;
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "PlayerBullet") {
			if (hp == 0) {
				anim.SetBool ("broken", true);
			} else {
				hp -= 1;
			}
		}
	}

}
