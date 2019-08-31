using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackBonus : MonoBehaviour
{
    public PlayerData player;
    public string NextLevel;

    public void Activate()
    {
        player.Cooldown *= .99f;
        SceneManager.LoadScene(NextLevel);
    }
}
