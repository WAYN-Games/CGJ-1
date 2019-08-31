using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 StartPosition;
    private bool Aggroed = false;

    public Transform Player;
    public float AggroRadius;
    public float Acceleration;
    public float MaxSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }
    
    private void FixedUpdate()
    {
        if (Player != null && (Vector3.Distance(Player.position,transform.position) <= AggroRadius || Aggroed) )
        {
            rb.AddForce(new Vector2(Player.position.x - transform.position.x, Player.position.y - transform.position.y).normalized * Acceleration);
            if(rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * MaxSpeed;
            }
            if(Player.position.x > transform.position.x)
            {
                FlipGraphics(0);
            }
            else
            {
                FlipGraphics(180);
            }
            Aggroed = true;
        }
    }

    private void FlipGraphics(int Side)
    {
        transform.eulerAngles = new Vector3(0, Side, 0); // Flipped
    }


    public void Reset()
    {
        transform.position = StartPosition;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        Aggroed = false;
        gameObject.SetActive(true);
    }

}
