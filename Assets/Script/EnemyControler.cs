using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 StartPosition;

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
        if (Player != null && Vector3.Distance(Player.position,transform.position) <= AggroRadius && rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(new Vector2(Player.position.x - transform.position.x,0).normalized * Acceleration);
        }
    }

    public void Reset()
    {
        transform.position = StartPosition;
        rb.velocity = Vector2.zero;
    }

}
