using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float forceBoost = 800f;

    #region PlayerShoot
    public Transform PlayerFirePoint;
    public GameObject PlayerBullet;
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

    [SerializeField] private float runSpeedHorizontal = 3, runSpeedVertical = 3, runSpeed = 0, jumpForce = 2;
    private float horizontalMove = 0, verticalMove = 0;

    private Rigidbody2D rb;
    private bool isGrounded;

    #endregion
    void Start()
    {
        CurrentHP = HPmax;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (joystick.Vertical >.5f && isGrounded)
        {
            Jump();
            isGrounded = false;
        }
        verticalMove = joystick.Vertical * runSpeedVertical; horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;







        Shoot();
        ComprobarHP();
    }
    private void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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





























    public void ManageShot()
    {
        Instantiate(PlayerBullet, PlayerFirePoint.position, PlayerFirePoint.rotation);
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.K))
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
        if (Input.GetKeyDown(KeyCode.Escape))
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
