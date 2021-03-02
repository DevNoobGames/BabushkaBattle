using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public Camera CAM;

    public Material Red;
    public Material Green;


    private void Start()
    {
        CAM = Camera.main;
    }
    void Update()
    {
            RaycastHit hit;
            Ray ray = CAM.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                int Y = (Mathf.RoundToInt(hit.point.y));
                transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), Y, Mathf.RoundToInt(hit.point.z));
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (Input.GetMouseButtonDown(1)) 
            {
                GameObject Turret = Instantiate(Resources.Load("BuildingCubePlaceTest"), transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material = Red;
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material = Green;
    }
}
