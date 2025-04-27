using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int enemyHealth;
    public int maxhealth = 150;
    public EnemyHealthbar healthbar;
    public EnemyState enemyState;
    float timediscovered;
    bool run;
    bool discovered;

    private void Start()
    {
        enemyState = GetComponent<EnemyState>();
        enemyHealth = maxhealth;
        healthbar.SetMaxHealth(enemyHealth);
    }


    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (!run)
        {
            enemyState.SetState(EnemyState.BadGuystate.Attack);
           discovered = true;
        }
        else
        {
            enemyState.SetState(EnemyState.BadGuystate.Disengage);
            discovered = true;
        }

        if (enemyHealth <= 0)
        {
            enemyState.SetState(EnemyState.BadGuystate.Dead);
        }
    }

    private void Update()
    {
        healthbar.SetHealth(enemyHealth);
        if (!run && enemyHealth <= (int)maxhealth * .3f) //using percentage to make the enemy start running away.
        {
            enemyState.SetState(EnemyState.BadGuystate.Disengage);
            run = true;
        }

        if (discovered)
        {

            timediscovered += Time.deltaTime;
            if (timediscovered > 10f)
            {
                //a lot of the same stuff we have already done by reseting the enemy if enough time has past.
                timediscovered = 0;
                enemyState.SetState(EnemyState.BadGuystate.Detect);
                discovered = false;
            }
        }

    }

}


