using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject CreditPanel;

    [Header ("To set active")]
     public GameObject IntroMove;
    public GameObject IntroPanel;

    [Header("To Deactivate")]
    public GameObject mainMenuCam;
    public GameObject ThismainMenu;

    public void StartGame()
    {
        IntroMove.SetActive(true);
        IntroPanel.SetActive(true);
        mainMenuCam.SetActive(false);
        ThismainMenu.SetActive(false); 
    }

    public void Credits()
    {
        Debug.Log("Open creds");
        if (!CreditPanel.activeInHierarchy)
        {
            CreditPanel.SetActive(true);
        }
        else
        {
            CreditPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
