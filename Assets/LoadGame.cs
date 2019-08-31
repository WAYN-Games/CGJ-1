using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject credit;
    public GameObject MainMenu;

    public void LoadCredit()
    {
        credit.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("GameScene_1");
    }
    public void LoadMainMenu()
    {
        MainMenu.SetActive(true);
        credit.SetActive(false);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
