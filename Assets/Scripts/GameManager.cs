using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] float time;
	[SerializeField] Text textTime;
	[SerializeField] Text textScore;
	[SerializeField] Text textBullet;
	[SerializeField] Text textBulletBox;
	public GameObject snipe;
	public ScoreManager scoreManager;
	public BulletController bullet;
	public TargetController target;

	// Use this for initialization
	void Start () {
		time = 90;
	}
	
	// Update is called once per frame
	void Update () {
		showTime ();
		showScore ();
		showBulletNums ();
	}

	private void showTime(){
		time -= Time.deltaTime;
		textTime.text = "Time :" + time.ToString("N1");
	}

	private void showScore(){
		textScore.text = "Pt :" + scoreManager.targetScore.ToString ();
	}

	private void showBulletNums(){
		textBullet.text = "Bullet :" + bullet.bulletCount.ToString ();
		textBulletBox.text = "BulletBox :" + bullet.bulletBoxCount.ToString ();
	}

}