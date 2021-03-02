using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DollUpgradeSign : MonoBehaviour
{
    public float TheDistance;
    public TextMeshProUGUI InfoText;
    public GameObject player;
    public PlayerStats Playerstats;
    public float Price;
    public AudioSource upgradeAdio;
    void Start()
    {
        TheDistance = 99999;
    }

    private void OnMouseOver()
    {
        TheDistance = Vector3.Distance(transform.position, player.transform.position);

        if (TheDistance <= 4)
        {
            if (Playerstats.MatryoshkaLevel < 5)
            {
                InfoText.text = "Level " + Playerstats.MatryoshkaLevel + "/5" + "\n" + Price.ToString("F0") + "$ [E]";
                if (Input.GetButtonDown("Action"))
                {
                    if (TheDistance <= 4 && Playerstats.Money >= Price)
                    {
                        Playerstats.Money -= Price;
                        Price *= 2f;
                        Price = Mathf.Round(Price);
                        upgradeAdio.Play();
                        Playerstats.MatryoshkaLevel += 1;
                        InfoText.text = Price.ToString("F0") + "$ [E]";
                        if (Playerstats.MatryoshkaLevel == 5)
                        {
                            TheDistance = 99999;
                        }
                        Playerstats.UpdateMoneyText();
                    }
                }
            }
            else
            {
                InfoText.text = "Level " + Playerstats.MatryoshkaLevel + "/5" + "\n" + "Maxed Out";
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
