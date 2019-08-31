
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Player;
    private AudioSource AudioSource;
    private bool IsDead = false;
    private bool IsGrounded = false;
    private Vector3 StartPosition;
    private Animator Animator;
    private int CurrentJumpCount = 0;
    private float CurrentCooldown;
    public Collider2D DamageArea;

    public AudioClip JumpClip;
    public AudioClip DeathClip;
    public AudioClip AtackClip;

    public Text EndGameTextField;
    [TextArea(2,2)]
    public string EndGameText;
    private bool isGameOver = false;

    public PlayerData PlayerData;
    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponentInChildren<Animator>();
        StartPosition = transform.position;
    }
       
    private void FixedUpdate()
    {
        if (isGameOver)
        {
            if (!AudioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
            return;
        }
        

        Animator.SetBool("Attack", false);
        if (!IsDead)
        {
            if (Input.GetKey(KeyCode.D) && Player.velocity.x < PlayerData.MaxSpeed)
            {
                Player.AddForce(Vector2.right * PlayerData.Acceleration);
                FlipGraphics(0);
            }
            if (Input.GetKey(KeyCode.Q) && Player.velocity.x > -PlayerData.MaxSpeed)
            {
                Player.AddForce(Vector2.left * PlayerData.Acceleration);
                FlipGraphics(180);
            }
            if(PlayerData.JumpCount > 0) { 
                if (Input.GetKeyDown(KeyCode.Z) && Player.velocity.y < PlayerData.MaxSpeed && (IsGrounded || CurrentJumpCount < PlayerData.JumpCount))
                {
                    Player.AddForce(Vector2.up * PlayerData.JumpForce);
                    CurrentJumpCount++;
                    AudioSource.clip = JumpClip;
                    AudioSource.Play();
                }
            }
            if (Input.GetMouseButton(1) && CurrentCooldown < 0 && PlayerData.Cooldown < 1)
            {
                CurrentCooldown = PlayerData.Cooldown;
                DamageArea.gameObject.SetActive(true);
                AudioSource.clip = AtackClip;
                Animator.SetBool("Attack", true);
                AudioSource.Play();
            }
            else
            {
                DamageArea.gameObject.SetActive(false);
            }
        }
        if (IsGrounded)
        {
            Animator.SetFloat("Speed", Math.Abs(Player.velocity.x));
        }
        else
        {
            Animator.SetFloat("Speed", 0);
        }

        CurrentCooldown -= Time.fixedDeltaTime;



    }
   
    private void FlipGraphics(int Side)
    {
        transform.eulerAngles = new Vector3(0, Side, 0); // Flipped
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        int colLayer = col.transform.gameObject.layer;
        if (colLayer == 9 && !IsDead)
        {
            AudioSource.clip = DeathClip;
            AudioSource.Play();
            IsDead = true;
        }
        if (colLayer == 10)
        {
            IsGrounded = true;
            CurrentJumpCount = 0;
        }
        if (colLayer == 12 && !isGameOver)
        { 
            AudioSource.clip = DeathClip;
            AudioSource.Play();
            isGameOver = true;           
            EndGameTextField.text = EndGameText;
        } 

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        int colLayer = collision.transform.gameObject.layer;

        if(colLayer == 10)
        {
            IsGrounded = false;
        }
    }

    private void LateUpdate()
    {
        if(IsDead && !AudioSource.isPlaying)
        {
            transform.position = StartPosition;
            IsDead = false;
            EnemyControler[] enemies = (EnemyControler[] )Resources.FindObjectsOfTypeAll(typeof(EnemyControler));

            foreach (var enemy in enemies)
            {
                enemy.Reset();
            }
        }
    }


}
