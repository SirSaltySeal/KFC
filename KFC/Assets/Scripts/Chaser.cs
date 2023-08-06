using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agentComponent;

    [SerializeField]
    Transform chasePlayer;
    private void Awake()
    {
        agentComponent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agentComponent.SetDestination(chasePlayer.position);
    }
}
