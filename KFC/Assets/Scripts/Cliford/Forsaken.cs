using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Forsaken : MonoBehaviour
{
    public float Damage;
    public Transform Target;
    public float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);
        while (enabled)
        {
            Agent.SetDestination(Target.transform.position);
            yield return Wait;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<PlayerHealth>().playerTakeDamage(Damage);
        Debug.Log(gameObject);
    }
}
