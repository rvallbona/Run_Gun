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
    private void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        scriptPlayer = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        Patrol();
    }
    void Patrol() {
        transform.position = Vector3.MoveTowards (transform.position,
                                                 wayPoints[waypointIndex].transform.position,
                                                 velocidad * Time.deltaTime);
        if (transform.position == wayPoints [waypointIndex].transform.position)
        {
            waypointIndex++;
        }
        if (waypointIndex == wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            scriptPlayer.PlayerHit(1);
            Debug.Log("PlayerHP: " + scriptPlayer.CurrentHP);
        }
    }
}