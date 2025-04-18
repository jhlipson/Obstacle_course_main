using UnityEngine;

public class Bullet : MonoBehaviour
{

  

    public int damage = 10;
   
    private void Start()
    {
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the pellet hits an enemy
        EnemyTakeDamage target = collision.transform.GetComponent<EnemyTakeDamage>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log("Enemy hit by pellet!");
        }

      
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        // Check if the pellet hits an enemy
        EnemyTakeDamage target = other.transform.GetComponent<EnemyTakeDamage>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log("Enemy hit by pellet!");
        }

        // Destroy pellet after collision with any object
        Destroy(gameObject);
    } 
}
