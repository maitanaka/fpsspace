using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	[SerializeField] int hp;
	[SerializeField] Transform headMarker;
	[SerializeField] ScoreManager score;
	public Animator anim;

	// Use this for initialization
	void Start () {
		hp = 5;
		anim = GetComponent<Animator>();
	}

	public void ShootTarget(RaycastHit hit){
		float distance = Vector3.Distance(hit.point, headMarker.position);
		if (distance <= 0.1) {
			score.targetScore += 5;
		} else {
			score.targetScore += 2;
		}

		hp -= 1;

		if (hp == 0) {
			anim.SetBool ("broken", true);
			Invoke ("Recover", 5);
		}
	}

	private void Recover(){
		anim.SetBool ("broken", false);
		hp = 5;
	}
}
