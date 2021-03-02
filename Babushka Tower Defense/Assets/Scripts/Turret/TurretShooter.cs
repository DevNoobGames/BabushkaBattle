using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    public GameObject Target;
    public RaycastHit hit;
    public RaycastHit Shot;
    GameObject ebullet;
    public bool reloaded;

    public float Damage;
    public float Range;

    private void Start()
    {
        ebullet = Resources.Load("eBullet") as GameObject;
        GetComponent<SphereCollider>().radius = Range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bear"))
        {
            if (!Target)
            {
                Target = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bear"))
        {
            if (other.gameObject == Target)
            {
                Target = null;
            }
        }
    }

    private void Update()
    {
        if (Target)
        {
            Vector3 targetPostition = new Vector3(Target.transform.position.x,
                                    transform.parent.position.y,
                                    Target.transform.position.z);
            transform.parent.LookAt(targetPostition);

            if (reloaded)
            {
                reloaded = false;
                GameObject bullets = Instantiate(ebullet, transform.parent.position, Quaternion.identity) as GameObject;
                bullets.transform.LookAt(Target.transform);
                bullets.GetComponent<BulletScr>().damage = Damage;
                Rigidbody rb = bullets.GetComponent<Rigidbody>();
                Vector3 targetPos = new Vector3(Target.transform.position.x, Target.transform.position.y + 1, Target.transform.position.z);
                rb.AddForce((targetPos - transform.parent.position).normalized * 1500);
                Destroy(bullets, 4f);
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        int randVal = Random.Range(1, 3);
        yield return new WaitForSeconds(randVal);
        reloaded = true;
    }
}
