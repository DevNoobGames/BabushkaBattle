using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlacementTest : MonoBehaviour
{
    public Camera CAM;
    public Transform SpawnPos;
    public bool canBuild;
    public GameObject Player;
    public PlayerStats stats;
    public float Cost;

    void Start()
    {
        CAM = Camera.main;
        canBuild = true;
        Player = GameObject.Find("Babushka");
        stats = Player.GetComponent<PlayerStats>();
        Cost = stats.MatryoshkaCost;
        transform.GetChild(stats.MatryoshkaLevel - 1).gameObject.SetActive(true);
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = CAM.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }
        if (Input.GetMouseButtonDown(1) && canBuild)
        {
            
            string TurretToLoad = "Matry" + stats.MatryoshkaLevel.ToString();
            GameObject Turret = Instantiate(Resources.Load(TurretToLoad), SpawnPos.position, Quaternion.identity) as GameObject;
            CAM.GetComponent<PlayerCasting>().BuildingActive = false;
            if (stats.TutNumber != 1)
            {
                stats.Money -= Cost;
                stats.MatryoshkaCost *= 1.2f;
                stats.MatryoshkaCost = Mathf.Round(stats.MatryoshkaCost);
                stats.UpdateMoneyText();
                stats.UpdateMatryCostText();
            }
            else
            {
                stats.TutNumber = 2;
                stats.Tut2();
            }
            Destroy(gameObject);
        }
    }
}
