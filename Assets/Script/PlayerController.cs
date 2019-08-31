
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Player;
    private AudioSource AudioSource;
    private bool IsDead = false;
    private bool IsGrounded = false;
    private Vector3 StartPosition;
    private Animator Animator;
    private int CurrentJumpCount = 0;

    public AudioClip JumpClip;
    public AudioClip DeathClip;

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
            if (Input.GetKeyDown(KeyCode.Z) && Player.velocity.y < PlayerData.MaxSpeed && (IsGrounded || CurrentJumpCount < PlayerData.JumpCount))
            {
                Player.AddForce(Vector2.up * PlayerData.JumpForce);
                CurrentJumpCount++;
                AudioSource.clip = JumpClip;
                AudioSource.Play();
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
            EnemyControler[] enemies = FindObjectsOfType<EnemyControler>();
            foreach (var enemy in enemies)
            {
                enemy.Reset();
            }
        }
    }


}
