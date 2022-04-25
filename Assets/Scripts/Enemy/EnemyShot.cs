using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	public GameObject Shot;
	public Transform BulletSpawn;
	public float fireRate;
	private float nextFire;
	//heal
	public float EnemyHPmax;
	public float EnemyCurrentHP;

	Animator anim;

	GameObject player;
	PlayerController playerScript;

	GameManager gm;
	private void Start()
    {
		EnemyCurrentHP += EnemyHPmax;
		player = GameObject.FindGameObjectWithTag("Player");

	}
    void Update () 
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			EnemyShoot();
			
		}
		ComprobarHPEnemy();
		CheckPlayerPossitionandRotation();
	}

	public void EnemyHit(int daño)
	{
		EnemyCurrentHP -= daño;
		Debug.Log(EnemyCurrentHP);
	}
	void EnemyShoot() {

		Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
	}
	void ComprobarHPEnemy() {
		if (EnemyCurrentHP <= 0)
		{
			EnemyDie();
		}
	}
	void EnemyDie() {
		Destroy(gameObject, 0);
		gm.IncreasePlayerScore(3);
		gm.GetPlayerScore();
		Debug.Log("TE LO HAS CARGADO");
	}
	void CheckPlayerPossitionandRotation() {
		if (player.transform.position.x < this.transform.position.x)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		else if (player.transform.position.x > this.transform.position.x)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
 //   private void OnCollisionEnter2D(Collision2D collision)
 //   {
	//	if (collision.collider.CompareTag("Player"))
	//	{
	//		playerScript.PlayerDie();
	//		Debug.Log("OnShootDead: " + playerScript.CurrentHP);
	//	}

	//}
}