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
}