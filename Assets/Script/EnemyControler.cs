using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform Player;
    public float AggroRadius;
    public float Acceleration;
    public float MaxSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (Player != null && Vector3.Distance(Player.position,transform.position) <= AggroRadius && rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(new Vector2(Player.position.x - transform.position.x,0).normalized * Acceleration);
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (Player != null && Player.CompareTag(col.collider.tag))
        {
            Destroy(Player.gameObject);
        }
    }
}
