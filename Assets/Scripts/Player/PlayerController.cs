using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float forceBoost = 800f;

    #region PlayerShoot
    public Transform PlayerFirePoint;
    public GameObject PlayerBullet;
    public float bulletSpeed = 10f;
    #endregion
    #region hp
    public float HPmax;
    public float CurrentHP;
    public Slider healthSlider;
    public int CuraVida;
    #endregion
    bool pause;

    #region PlayerControllers
    [SerializeField] Joystick joystick;

    [SerializeField] private float runSpeedHorizontal, runSpeedVertical, runSpeed, jumpForce;
    private float horizontalMoveJoystick = 0, verticalMoveJoystick = 0;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator anim;
    private bool facingRight = true;
    #endregion

    void Start()
    {
        CurrentHP = HPmax;
        rb = GetComponent<Rigidbody2D>(); 
        anim = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        horizontalMoveJoystick = joystick.Horizontal * runSpeedHorizontal;
        verticalMoveJoystick = joystick.Vertical * runSpeedVertical;

        transform.position += new Vector3(horizontalMoveJoystick, 0, 0) * Time.deltaTime * runSpeed;

        float speed = Mathf.Abs(horizontalMoveJoystick);
        anim.SetFloat("Speed", speed);

        if (joystick.Vertical > 0.5f && isGrounded)
        {
            Jump();
            isGrounded = false;
            anim.SetTrigger("JumpTrigger");
        }

        anim.SetBool("isGrounded", isGrounded);

        if (horizontalMoveJoystick > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalMoveJoystick < 0 && facingRight)
        {
            Flip();
        }

        Shoot();
        ComprobarHP();
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Grounded")
        {
            isGrounded = true;
        }
        if (collision.transform.tag == "EnemyFly")
        {
            PlayerHit(5);
        }
    }
    private void Flip()
    {
        // Cambiar la dirección del sprite
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Invertir el eje X
        transform.localScale = localScale;
    }
    public void ManageShot()
    {
        GameObject bullet = Instantiate(PlayerBullet, PlayerFirePoint.position, Quaternion.identity);

        BulletPlayerController bulletController = bullet.GetComponent<BulletPlayerController>();

        if (bulletController != null)
        {
            bulletController.SetDirection(facingRight ? Vector2.right : Vector2.left);
        }
    }
    void Shoot()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.K))
        {
            ManageShot();
        }
    }
    public void PlayerHit(int daño)
    {
        CurrentHP -= daño;
        healthSlider.value = CurrentHP;
    }
    public void ComprobarHP()
    {
        if (CurrentHP <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Dead", true);
            PlayerDie();
        }
    }
    public void PlayerDie()
    {
        Destroy(gameObject, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatformJump")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceBoost));
        }
        if (collision.tag == "Potion")
        {
            CurrentHP += CuraVida;
            healthSlider.value = CurrentHP;
        }
    }
    public void OpenPauseMenu()
    {
        GameManager.Instance.PauseGame();
        //PauseMenu.SetActive(true);
        //pause = true;
    }
    public void ClosePauseMenu()
    {
        GameManager.Instance.ResumeGame();
        //PauseMenu.SetActive(false);
        //pause = false;
    }
    public void Pause()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                OpenPauseMenu();
            }
            else if (pause)
            {
                ClosePauseMenu();
            }
        }
    }
}
