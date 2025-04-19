using UnityEngine;

public class Detection : MonoBehaviour
{
    public Player player;
    public EnemyState enemyState;   
    public float timedetected = 10f;

    private bool playerInRange = false;

    void Update()
    {/*
        if (!playerInRange && timedetected > 0f)
        {
            timedetected -= Time.deltaTime;
            if (timedetected <= 0f)
            {
                enemyState.SetState(EnemyState.BadGuystate.Idle);
                Debug.Log("Timeout — going back to IDLE");
            }
        } */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            enemyState.SetState(EnemyState.BadGuystate.Follow);
            timedetected = 10f;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            enemyState.SetState(EnemyState.BadGuystate.Detect);
        } 
    } */

}
