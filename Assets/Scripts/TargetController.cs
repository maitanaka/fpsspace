using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public int hp;
	public Animator anim;

	// Use this for initialization
	void Start () {
		hp = 5;
		anim = GetComponent<Animator>();
	}
}
