using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RemoveTileColider : MonoBehaviour
{
    private TilemapCollider2D platforms;

    private void Awake()
    {
        platforms = GetComponent<TilemapCollider2D>();
    }

    private void Start()
    {
        platforms.enabled = false;
    }
}
