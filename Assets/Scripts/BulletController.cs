using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
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
}
