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
    private FightDetection fightDetection;  
    private Transform currentDestination;
    public Transform shootorigin;
    public EnemyState enemyState;
    public float timedetection = 10f;
    public float damage = 20f;
    public float range = 20f;
    public float resettime;
    public AudioSource Shootsound;
    Player pp;
    float cooldown;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponentInChildren<Detection>();
        currentDestination = destinationA;
        agent.destination = currentDestination.position;
        enemyState = GetComponent<EnemyState>();
        resettime = timedetection;
        fightDetection = GetComponentInChildren<FightDetection>();  
        pp = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        enemyState.CheckState();
    }
    //So here's what you have to do. Maneuver all of the code for the enemy to work with the state machine.
    //That means using public booleans I'd say to turn stuff off and on, that's your best bet.
    public void walking (bool walk)
    {
        
        if (walk)
        {
            agent.destination = currentDestination.position; 
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

    public void Detect(bool detect) 
    {
        EnemyState.BadGuystate currentstate = enemyState.GetState();
        if (detect && timedetection > 0)
        {

            Debug.Log("The follow option is false");
            agent.destination = detection.player.transform.position;
            timedetection -= Time.deltaTime;
            if (timedetection <= 0)
            {
                timedetection = resettime;
                Debug.Log("We be idle");
                enemyState.SetState(EnemyState.BadGuystate.Idle);
            }
        }
            
        
    }

    public void Shoot(bool shoot)
    {
        RaycastHit hit;
        
        agent.destination = fightDetection.player.transform.position;
        if(shoot && timedetection > 0)
        {
            cooldown += Time.deltaTime;
            if ((cooldown >= 3f))
            {
                Vector3 direction = (fightDetection.player.transform.position - shootorigin.position).normalized;
                if (Physics.Raycast(shootorigin.position, direction, out hit, range))
                { //We are getting first the origin of the shot, then the direction,
                    Shootsound.Play();
                    Debug.Log("Shooting!");
                    //We are using out hit to tell us if the ray cast does hit something to store it.
                    //finally, we are feeding the raycast our range for the shot.
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("Hit the player!");
                        cooldown = 0f;
                        pp.TakeDamage(damage); // feed it our enemy's damage on a hit.
                        Shootsound.Play();
                    }
                    else
                    {
                        Debug.Log("Raycast hit: " + hit.collider.name);
                    }
                }
                else
                {
                    Debug.Log("Missed!");
                }
            }
           
        }
      

    }

    public void Death(bool death)
    {
        if (death)
        {
            Destroy(gameObject);
        }
    }
}

