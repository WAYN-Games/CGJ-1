
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Player;

    public float Acceleration;
    public float MaxSpeed;
    public float JumpForce;

    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
    }
       
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && Player.velocity.x < MaxSpeed)
        {
            Player.AddForce(Vector2.right * Acceleration);
        }
        if (Input.GetKey(KeyCode.Q) && Player.velocity.x > -MaxSpeed)
        {
            Player.AddForce(Vector2.left * Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Z) && Player.velocity.y < MaxSpeed)
        {
            Player.AddForce(Vector2.up * JumpForce);
        }
    }


}
