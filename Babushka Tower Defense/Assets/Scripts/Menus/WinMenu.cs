using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public SpawnManager spawnMan;

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
        spawnMan.Level = 1;
        spawnMan.BearsToSpawn = 4;
        spawnMan.BearsAlive = spawnMan.BearsToSpawn;
        spawnMan.startingHealth = 90;
        spawnMan.BearSpawner();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }
}
