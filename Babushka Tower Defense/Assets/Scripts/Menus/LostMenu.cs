using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public TableWithFoodScr FoodScript;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        FoodScript.Health = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }
}
