using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI TutText;
    public int TutNumber;
    public GameObject SpawnMan;

    private void Start()
    {
        TutNumber = 1;
    }

    IEnumerator tut2N()
    {
        TutText.text = "Bears will come. Shoot them with the left mouse button. Buy upgrades at the store nearby. Good luck Babushka";
        yield return new WaitForSeconds(4);
        TutText.text = "";
    }

    public void Tut2()
    {
        SpawnMan.SetActive(true);
        StartCoroutine(tut2N());
    }
}
