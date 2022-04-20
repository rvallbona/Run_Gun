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
    private void Start()
    {
		EnemyCurrentHP += EnemyHPmax;

	}
    void Update () 
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
		}
		if (EnemyCurrentHP <= 0)
		{
			Destroy(gameObject, 0);
		}
	}

	public void EnemyHit(int daño)
	{
		EnemyCurrentHP -= daño;
	}
}