using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBonus : MonoBehaviour
{
    public PlayerData player;
    public string NextLevel;
    public float HeightPenalty;

    public void Activate()
    {
        player.JumpForce *= HeightPenalty;
        player.JumpCount++;
        SceneManager.LoadScene(NextLevel);
    }
}
