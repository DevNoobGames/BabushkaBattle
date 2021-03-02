using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget;
    public RaycastHit hit;
    public RaycastHit Shot;
    public GameObject HitParticle;
    public GameObject BuildingCubeTest;

    public bool BuildingActive;
    public int WeaponDamage;

    public PlayerStats stats;
    public AudioSource shotAudio;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            shotAudio.Play();
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    if (hit.transform.CompareTag("Untagged"))
                    {
                        GameObject Hitpartic = Instantiate(HitParticle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        Destroy(Hitpartic, 1);
                    }
                    if (hit.transform.CompareTag("Bear"))
                    {
                        GameObject Hitpartic = Instantiate(HitParticle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        Destroy(Hitpartic, 1);
                        hit.transform.SendMessage("Deduct", WeaponDamage, SendMessageOptions.DontRequireReceiver);
                    }
                }
        }

        if (Input.GetButtonDown("Fire2") && !BuildingActive && stats.Money >= stats.MatryoshkaCost)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    //Instantiate(Resources.Load("matryoshkaPlacer"), new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z)), Quaternion.FromToRotation(Vector3.up, hit.normal));
                    Instantiate(Resources.Load("matryoshka1Placer"), new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z)), Quaternion.identity);
                    BuildingActive = true;
                }
            }
        }
    }
}
