using UnityEngine;

public class Heal : MonoBehaviour
{
    public float heal = 15f;
   public Player player;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            player.currentHP += heal;
            Destroy(gameObject);
        }
    }
}
