using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementwithjoystck : MonoBehaviour
{
    private float hmove = 0,vmove = 0;
    public float runspeed = 0, runspeedH=3, runspeedV = 3;
    private Rigidbody2D rb;
    public Joystick joystick;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }
}
