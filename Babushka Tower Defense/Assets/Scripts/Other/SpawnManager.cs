using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public List<Vector3> SpawnPositions;
    public int BearsToSpawn;
    public int BearsAlive;
    public TextMeshProUGUI BearsAliveText;
    public float startingHealth;
    public bool Spawn;
    public int Level;
    public TextMeshProUGUI levelText;
    public AudioSource KilledAudio;
    public AudioSource nextLevelAudio;
    public GameObject winScreen;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            SpawnPositions.Add(child.transform.position);
        }
        Level = 1;
        levelText.text = "Level " + Level;
        BearsAlive = BearsToSpawn;
        BearSpawner();
    }

    public void KilledBear()
    {
        BearsAlive -= 1;
        BearsAliveText.text = BearsAlive + "/" + BearsToSpawn;
        KilledAudio.Play();
        if (BearsAlive <= 0)
        {
            Level += 1;
            if (Level <= 10)
            {
                BearsToSpawn += 2;
                BearsAlive = BearsToSpawn;
                nextLevelAudio.Play();
                BearSpawner();
                levelText.text = "Level " + Level;
            }
            else
            {
                Time.timeScale = 0;
                nextLevelAudio.Play();
                winScreen.SetActive(true);
            }
        }
    }

    public void BearSpawner()
    {
        for (int i = 0; i < BearsToSpawn; i++)
        {
            int randval = Random.Range(0, SpawnPositions.Count - 1);
            Instantiate(Resources.Load("BearFix2"), SpawnPositions[randval], Quaternion.identity);
        }

        startingHealth += 10;
        BearsAliveText.text = BearsAlive + "/" + BearsToSpawn;

        GameObject[] Bears = GameObject.FindGameObjectsWithTag("Bear");
        foreach (GameObject bear in Bears)
        {
            bear.GetComponent<BearScript>().Health = startingHealth;
        }
    }
}
