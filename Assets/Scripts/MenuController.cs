using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectMenu;

    public bool isMainMenu;

    public void Start()
    {
        if (isMainMenu)
        {
            mainMenu.SetActive(true);
            selectMenu.SetActive(false);
        }        
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        selectMenu.SetActive(true);
    }

    public void Options()
    {

    }

    public void Online()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Room");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        selectMenu.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
