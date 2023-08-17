using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public string currentState;
    public string nextState;

    public float idleTime;

    private NavMeshAgent agent;

    public Transform[] checkpoints;

    private int currentCheckpointIndex;

    private Transform playerToChase;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = "Idle";
        nextState = currentState;
        SwitchState();
    }

    private void Update()
    {
        if(currentState != nextState)
        {
            currentState = nextState;
        }
    }

    void SwitchState()
    {
        StartCoroutine(currentState);
    }


    public void SeePlayer(Transform player)
    {
        playerToChase = player;
        nextState = "Chase";
    }

    IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            yield return new WaitForSeconds(idleTime);

            nextState = "Patrol";
        }

        SwitchState();
    }

    IEnumerator Patrol()
    {
        ///Start Destination from checkpoint array "currentCheckpointIndex"
        agent.SetDestination(checkpoints[currentCheckpointIndex].position);

        bool hasReached = false;

        ///AI behavior
        while(currentState == "Patrol")
        {
            yield return null;
            if (!hasReached)
            {
                if(agent.remainingDistance <= agent.stoppingDistance)
                {
                    hasReached = true;

                    nextState = "Idle";

                    ///Go next checkpoint
                    ++currentCheckpointIndex;

                    if(currentCheckpointIndex >= checkpoints.Length)
                    {
                        currentCheckpointIndex = 0;
                    }
                }
            }
        }

        SwitchState();
    }

    IEnumerator Chase()
    {
        while(currentState == "Chase")
        {
            yield return null;
            if(playerToChase != null)
            {
                agent.SetDestination(playerToChase.position);
            }
            else
            {
                nextState = "Idle";
            }
        }
        SwitchState();
    }
}
