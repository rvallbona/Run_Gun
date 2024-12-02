using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float velocidad = 2f;
    int waypointIndex = 0;
    PlayerController scriptPlayer;
    GameObject player;

    public float EnemyPatrolHPmax;
    public float EnemyPatrolCurrentHP;
    private void Start()
    {
        if (wayPoints.Length > 0)
        {
            transform.position = wayPoints[waypointIndex].transform.position;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        scriptPlayer = player.GetComponent<PlayerController>();
        EnemyPatrolCurrentHP = EnemyPatrolHPmax;
    }
    void Update()
    {
        if (wayPoints.Length > 0)
        {
            Patrol();
        }
        ComprobarHPEnemyPatrol();
    }
    void Patrol() 
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 wayPoints[waypointIndex].transform.position,
                                                 velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[waypointIndex].transform.position) < 0.1f)
        {
            waypointIndex++;
        }

        if (waypointIndex >= wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            scriptPlayer.PlayerHit(1);
        }
    }
    public void EnemyPatrolHit(int daño)
    {
        EnemyPatrolCurrentHP -= daño;
        Debug.Log(EnemyPatrolCurrentHP);
    }
    void ComprobarHPEnemyPatrol()
    {
        if (EnemyPatrolCurrentHP <= 0)
        {
            EnemyPatrolDie();
        }
    }
    void EnemyPatrolDie()
    {

        Destroy(gameObject, 0);
    }
}