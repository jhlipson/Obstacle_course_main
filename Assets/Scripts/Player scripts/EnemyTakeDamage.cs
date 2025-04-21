using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int enemyHealth;
    public int maxhealth = 150;
    public EnemyHealthbar healthbar;
    public EnemyState enemyState;


    private void Start()
    {
        enemyState = GetComponent<EnemyState>(); 
        enemyHealth = maxhealth;
        healthbar.SetMaxHealth(enemyHealth);
    }

   
    public void TakeDamage (int damage)
    {
        enemyHealth -= damage;
       
        enemyState.SetState(EnemyState.BadGuystate.Follow);
        if (enemyHealth <= 0)
        {
            enemyState.SetState(EnemyState.BadGuystate.Dead);
        }
     }

    private void Update()
    {
        healthbar.SetHealth(enemyHealth);
    }

}
    

