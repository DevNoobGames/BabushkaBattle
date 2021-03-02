using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject Target;
    public PlayerStats stats;
    public GameObject TableWithFood;
    public float speed;
    public float StandardSpeed;
    public NavMeshObstacle obstacle;
    public float stoppingDistance;
    public bool isAttacking;
    public SpawnManager spawnManager;

    public Animation anim;

    public float Health;

    void Start()
    {
        stoppingDistance = Random.Range(3.0f, 3.3f);
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(0, 100);
        agent.speed = speed;

        Target = GameObject.FindGameObjectWithTag("TableWithFood");
        stats = GameObject.Find("Babushka").GetComponent<PlayerStats>();
        TableWithFood = GameObject.FindGameObjectWithTag("TableWithFood");
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            stats.Money += 20 + spawnManager.Level;
            stats.UpdateMoneyText();
            spawnManager.KilledBear();
            Destroy(gameObject);
        }

        if (Target)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > stoppingDistance) 
            {
                anim.Play("Walk3");
                agent.speed = speed;
                obstacle.enabled = false;
                agent.enabled = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                if (isAttacking)
                {
                    StopAllCoroutines();
                    isAttacking = false;
                }
            }
            else
            {
                anim.Play("Eat3");
                agent.speed = 0;
                obstacle.enabled = true;
                agent.enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(AttackPlayer());
                }
            }
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(Target.transform.position);
            }
            Vector3 targetPostition = new Vector3(Target.transform.position.x,
                                    this.transform.position.y,
                                    Target.transform.position.z);
            this.transform.LookAt(targetPostition);
        }
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        if (Target)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) <= stoppingDistance)
            {
                if (Target.CompareTag("TableWithFood"))
                {
                    if (TableWithFood.GetComponent<TableWithFoodScr>().Attackable == true)
                    {
                        //TableWithFood.GetComponent<TableWithFoodScr>().Attackable = false;
                        //TableWithFood.GetComponent<TableWithFoodScr>().Health -= 1;
                        //update health text
                        TableWithFood.GetComponent<TableWithFoodScr>().Attacked();
                    }
                }
            }
        }
        isAttacking = false;
    }

    void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
    }
}
