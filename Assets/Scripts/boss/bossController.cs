using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    //heal
    public float BossHPmax;
    public float BossCurrentHP;
    //shoot
    public GameObject Shot;
    public Transform BulletSpawn1;
    public Transform BulletSpawn2;
    public float fireRate;
    private float nextFire;

    Animator anim;

    GameObject player;
    PlayerController playerScript;
    void Start()
    {
        BossCurrentHP = BossHPmax;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BossShoot();

        }
        ComprobarHPBoss();
        CheckPlayerPossitionandRotation();
    }
    void BossShoot()
    {
        Instantiate(Shot, BulletSpawn1.position, BulletSpawn1.rotation);
        Instantiate(Shot, BulletSpawn2.position, BulletSpawn2.rotation);
    }
    public void BossHit(int daño)
    {
        BossCurrentHP -= daño;
        Debug.Log(BossCurrentHP);
    }
    void ComprobarHPBoss()
    {
        if (BossCurrentHP <= 0)
        {
            BossDie();
        }
    }
    void BossDie()
    {

        Destroy(gameObject, 0);
    }
    void CheckPlayerPossitionandRotation()
    {
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
