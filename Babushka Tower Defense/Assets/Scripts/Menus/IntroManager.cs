using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public GameObject Babu1;
    public GameObject Babu2;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    public bool CanSkip;
    public GameObject IntroPanel;

    [Header("To activate")]
    public GameObject Babushka;
    public GameObject Crosshairs;
    public GameObject InGameUI;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(IntroCor());
        CanSkip = true;
    }

    IEnumerator IntroCor()
    {
        introText.text = "My grandchildren are coming and are too skinny. let's give them all of the food [ESC TO SKIP]";
        yield return new WaitForSeconds(8);
        cam1.SetActive(false);
        cam2.SetActive(true);
        Babu1.SetActive(false);
        Babu2.SetActive(true);
        introText.text = "What a nice place for food, next to this random store [ESC TO SKIP]";
        yield return new WaitForSeconds(5);
        cam2.SetActive(false);
        cam3.SetActive(true);
        introText.text = "OH NO! [ESC TO SKIP]";
        yield return new WaitForSeconds(2);
        introText.text = "A group of hungry bears wanting to eat my food! [ESC TO SKIP]";
        yield return new WaitForSeconds(6);

        //PLAY
        Babushka.SetActive(true);
        Crosshairs.SetActive(true);
        InGameUI.SetActive(true);
        CanSkip = false;
        IntroPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanSkip)
            {
                Babushka.SetActive(true);
                Crosshairs.SetActive(true);
                InGameUI.SetActive(true);
                CanSkip = false;
                IntroPanel.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
