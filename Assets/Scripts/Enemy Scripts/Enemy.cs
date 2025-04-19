using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float dist_threshold = 0.25f;
    public Transform destinationA;
    public Transform destinationB;
    public Transform destinationC;
    private NavMeshAgent agent;
    private Detection detection;
    private Transform currentDestination;
    public EnemyState enemyState;
 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponentInChildren<Detection>();
        currentDestination = destinationA;
        agent.destination = currentDestination.position;
        enemyState = GetComponent<EnemyState>();
      

    }

    private void Update()
    {
        enemyState.CheckState();
    }
    //So here's what you have to do. Maneuver all of the code for the enemy to work with the state machine.
    //That means using public booleans I'd say to turn stuff off and on, that's your best bet.
    public void walking (bool walk)
    {
        EnemyState.BadGuystate currentstate = enemyState.GetState();
        if (walk)
        {
            currentstate = EnemyState.BadGuystate.Idle;
            if (Vector3.Distance(transform.position, currentDestination.position) < dist_threshold)
            {
                if (currentDestination == destinationA)
                {
                    currentDestination = destinationB;

                }
                else if (currentDestination == destinationB)
                {
                    currentDestination = destinationC;
                }
                else if (currentDestination == destinationC)
                {
                    currentDestination = destinationA;

                }
                agent.destination = currentDestination.position;
            }
        }
    }

    public void Follow (bool follow)
    {
        if(follow)
        {
            agent.destination = detection.player.transform.position;
        }
    }
    
}

