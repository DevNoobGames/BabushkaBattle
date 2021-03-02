using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableWithFoodScr : MonoBehaviour
{
    public int Health;
    public bool Attackable;
    public TextMeshProUGUI FoodLeftText;

    public Slider slider;
    public AudioSource eatSound;

    public GameObject LostMenu;

    void Start()
    {
        Attackable = true;
    }

    public void Attacked()
    {
        StartCoroutine(Injured());
    }

    public IEnumerator Injured()
    {
        Attackable = false;
        eatSound.Play();
        Health -= 1;
        slider.value = Health;
        if (Health <= 0)
        {
            Time.timeScale = 0;
            LostMenu.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        Attackable = true;
        FoodLeftText.text = Health + " food left";
    }
}
