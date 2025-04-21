using UnityEngine;

public class Detection : MonoBehaviour
{
    public Player player;
    public EnemyState enemyState;   
    public float timedetected = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            enemyState.SetState(EnemyState.BadGuystate.Follow);
            timedetected = 10f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            enemyState.SetState(EnemyState.BadGuystate.Detect);
        } 
    } 

}
