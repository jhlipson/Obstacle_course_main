using UnityEngine;

public class Detection : MonoBehaviour
{
    public Player player;
    public EnemyState enemyState;
    public GameObject fighdetection;
  


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(fighdetection != null)
            {
                enemyState.SetState(EnemyState.BadGuystate.Follow);
        
            } else
            {
                enemyState.SetState(EnemyState.BadGuystate.Disengage);  
            }
       
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
