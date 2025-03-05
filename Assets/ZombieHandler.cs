using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHandler : MonoBehaviour
{
    public float health;
    public GameObject deadEffect;
    public NavMeshAgent navMeshAgent;


    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Automatically assigns the NavMeshAgent
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        float _distance = Vector3.Distance(transform.position, target.position);

        if (_distance > 2)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            //Attack
        }

    }

    public void TakeDamage()
    {
        health -= 10;
        if (health <= 0)
        {
            //die
            GameObject _effect = Instantiate(deadEffect, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            Destroy(_effect, 3f);
            Destroy(gameObject);

        }
    }

}