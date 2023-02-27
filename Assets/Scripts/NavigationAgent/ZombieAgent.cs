using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAgent(bool isStopped)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        agent.isStopped = isStopped;
    }

    public void MoveToPosition(Vector3 position)
    {
        if (agent.isStopped)
        {
            agent.isStopped = false;
        }

        agent.SetDestination(position);
        Debug.Log(position);
        Debug.Log("This is changing the position");
    }
}
