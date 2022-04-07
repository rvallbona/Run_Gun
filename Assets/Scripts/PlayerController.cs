using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump;
    public float forceRight = 800f;
    public float forceLeft = -800f;
    public float forceJump = 300f;
    void Start()
    {

    }
    void Update()
    {
        MoveLeftRight();
        Jump();
    }
    void MoveManual() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-30f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(30f * Time.deltaTime, 0, 0);
        }
        ManageJump();
    }
    void ManageJump() 
    {
        if (gameObject.transform.position.y <= 0)
        {
            canJump = true;
        }
        if (Input.GetKey(KeyCode.Space) && canJump && gameObject.transform.position.y < 10)
        {
            gameObject.transform.Translate(0, 100f * Time.deltaTime, 0);
        }
        else
        {
            canJump = false;

            if (gameObject.transform.position.y > 0 )
            {
                gameObject.transform.Translate(0, -30f * Time.deltaTime, 0);
            }
        }
    }
    void MoveLeftRight()
    {
        if (Input.GetKey(KeyCode.A))//LEFT
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceLeft * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;//animation
        }
        if (Input.GetKey(KeyCode.D))//RIGHT
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceRight * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;//animation
        }
        //animation
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        //animation
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)//GetKeyDown imortante para que no se tenga que mantener pulsado
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceJump));//el 500f es la fuerza del salto.
        }
        //animation
        if (!canJump)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        if (canJump)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
        }
        //animation
    }
    //SOLUCIONAR PROBLEMA DEL SALT!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Grounded")
        {
            canJump = true;
        }
    }
}