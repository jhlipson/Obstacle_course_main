using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int enemyHealth = 100;
    [SerializeField] bool destroyOnDeath = true;
  


    public void TakeDamage (int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0 && destroyOnDeath)
        {
        
            Destroy(gameObject);    
        }
    }
    
}
    

