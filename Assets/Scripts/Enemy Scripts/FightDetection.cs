using Unity.VisualScripting;
using UnityEngine;

public class FightDetection : MonoBehaviour
{
    EnemyState enemyState;
    public Player player;
    public GameObject otherdetecter;
    public bool tracking = false;
    public float timedetected = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyState = GetComponentInParent<EnemyState>();    
        player = FindFirstObjectByType<Player>();   
    }

    private void Update()
    {
        if(tracking)
        {
            timedetected -= Time.deltaTime;
          
        }
        if (timedetected <= 0)
        {
            otherdetecter.SetActive(true);
            enemyState.SetState(EnemyState.BadGuystate.Idle);
            tracking = false;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timedetected = 10f;
            enemyState.SetState(EnemyState.BadGuystate.Attack);
            otherdetecter.SetActive(false);
            tracking = false; // tracking is only if you leave outside its range so the enemy must chase you down.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyState.SetState(EnemyState.BadGuystate.Attack);
            tracking = true;  
          
        }
    }
}
