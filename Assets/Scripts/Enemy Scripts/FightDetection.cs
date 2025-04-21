using UnityEngine;

public class FightDetection : MonoBehaviour
{
    EnemyState enemyState;
    public Player player;  
    public float timedetected = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyState = GetComponentInParent<EnemyState>();    
        player = FindFirstObjectByType<Player>();   
    }

   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemyState.SetState(EnemyState.BadGuystate.Attack);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyState.SetState(EnemyState.BadGuystate.Attack);
            timedetected -= Time.deltaTime;
            if (timedetected <= 0)
            {
                enemyState.SetState(EnemyState.BadGuystate.Detect);
                timedetected = 10f;
            }
        }
    }
}
