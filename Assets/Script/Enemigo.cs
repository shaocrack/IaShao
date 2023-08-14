using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
    

{
    public Transform target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent!= null)
        {
            agent.SetDestination(target.position);
            {
                if (Vector3.Distance(transform.transform.position,target.position)<2f)
                {
                    
                }
            }

        }
    }
}
