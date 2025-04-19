using UnityEngine;

public class Detection : MonoBehaviour
{
    public Player player;
    public EnemyState enemyState;   
    public bool detect;
    public float timedetected = 10f;


    private void OnTriggerEnter(Collider other)
    {

      EnemyState.BadGuystate currentstate = enemyState.GetState();
        if (other.gameObject.CompareTag("Player"))
        {
            currentstate = EnemyState.BadGuystate.Detect;
            detect = true;
            timedetected = 10f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detect = true;
            timedetected -= Time.time;
        }
    }
}
