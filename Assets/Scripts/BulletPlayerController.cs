using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : MonoBehaviour
{
    private Rigidbody2D rB;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 0.5f);
    }
    //Destruimos la bala cuando choca.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Recibir Daño.
            EnemyShot enemy = collision.GetComponent<EnemyShot>();
            enemy.EnemyHit(1);
            Debug.Log("EnemyHP: " + enemy.EnemyCurrentHP);
            
        }
        if (collision.tag == "EnemyPatrol")
        {
            EnemyPatrol enemyPatrol = collision.GetComponent<EnemyPatrol>();
            enemyPatrol.EnemyPatrolHit(1);
            Debug.Log("EnemyPatrolHP: " + enemyPatrol.EnemyPatrolCurrentHP);
        }
        if (collision.tag == "Boss")
        {
            bossController boss = collision.GetComponent<bossController>();
            boss.BossHit(1);
            Debug.Log("BossHP: " + boss.BossCurrentHP);
        }
        Destroy(gameObject, 0);
    }
}
