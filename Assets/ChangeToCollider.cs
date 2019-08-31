using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToCollider : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
