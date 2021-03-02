using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float Money;
    public TextMeshProUGUI MoneyText;

    public int MatryoshkaLevel;
    public float MatryoshkaCost;
    public TextMeshProUGUI MatryCostText;

    public int WeaponLevel;
    public TextMeshProUGUI WeaponlevelText;

    public TextMeshProUGUI TutText;
    public int TutNumber;
    public GameObject SpawnMan;

    public GameObject PauseMen;

    private void Start()
    {
        TutNumber = 1;
    }

    IEnumerator tut2N()
    {
        TutText.text = "Bears will come. Shoot them with the left mouse button. Buy upgrades at the store nearby. Good luck Babushka";
        yield return new WaitForSeconds(10);
        TutText.text = "";
    }

    public void Tut2()
    {
        SpawnMan.SetActive(true);
        StartCoroutine(tut2N());
    }

    public void UpdateMoneyText()
    {
        MoneyText.text = Money + "$";
    }

    public void UpdateMatryCostText()
    {
        MatryCostText.text = MatryoshkaCost + "$";
    }

    public void UpdateWeaponLevelText()
    {
        WeaponlevelText.text = WeaponLevel.ToString(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMen.activeInHierarchy)
            {
                PauseMen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PauseMen.SetActive(false);
            }
        }
    }
}
