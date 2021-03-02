using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear"))
        {
            other.GetComponent<BearScript>().Health -= damage;
            Destroy(gameObject);
        }
    }
}
