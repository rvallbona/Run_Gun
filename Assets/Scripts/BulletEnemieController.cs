using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemieController : MonoBehaviour
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
        if (collision.tag == "Player")
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.PlayerHit(1);
            Debug.Log("PlayerHP: " + playerController.CurrentHP);
        }
        Destroy(gameObject, 0);    
    }
}
