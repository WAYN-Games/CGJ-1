using UnityEngine;

public class Damage : MonoBehaviour
{
    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.layer == 9)
        {
            collision.transform.gameObject.SetActive(false);
        }
    }
}
