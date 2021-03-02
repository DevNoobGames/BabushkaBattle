using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalkingStickSign : MonoBehaviour
{
    public float TheDistance;
    public TextMeshProUGUI InfoText;
    public GameObject player;
    public PlayerStats Playerstats;
    public PlayerCasting WeaponDamage;
    public float Price;
    public AudioSource upgradeAudio;

    void Start()
    {
        TheDistance = 99999;
    }

    private void OnMouseOver()
    {
        TheDistance = Vector3.Distance(transform.position, player.transform.position);

        if (TheDistance <= 4)
        {
            InfoText.text = Price.ToString("F0") + "$ [E]";
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 4 && Playerstats.Money >= Price)
                {
                    Playerstats.Money -= Price;
                    Debug.Log("Buy");
                    Price *= 1.5f;
                    Price = Mathf.Round(Price);
                    upgradeAudio.Play();
                    Playerstats.WeaponLevel += 1;
                    WeaponDamage.WeaponDamage += 2;
                    InfoText.text = Price.ToString("F0") + "$ [E]";
                    Playerstats.UpdateMoneyText();
                    Playerstats.UpdateWeaponLevelText();
                }
            }
        }
        if (TheDistance > 4)
        {
            InfoText.text = "";
        }


    }

    void OnMouseExit()
    {
        InfoText.text = "";
    }
}
