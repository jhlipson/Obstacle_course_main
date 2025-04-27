using UnityEngine;

public class Heal : MonoBehaviour
{
    public float heal = 15f;
   public OGPlayer player;

    void Start()
    {
        player = FindFirstObjectByType<OGPlayer>();
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
