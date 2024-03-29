﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject UIPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.layer==8)
            UIPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.gameObject.layer == 8)
            UIPanel.SetActive(false);
    }
}
