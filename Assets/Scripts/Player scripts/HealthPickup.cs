using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float heal = 15f;
    public Player player;
    public AudioSource eat; // taken from https://classicgaming.cc/classics/pac-man/sounds#google_vignette
   
    void Start()
    {
        player = FindAnyObjectByType< Player >();
        GameObject healthPickupSoundObject = GameObject.Find("Health pickup sound effect");
        if (healthPickupSoundObject != null)
        {
            // Get the AudioSource from the found GameObject
            eat = healthPickupSoundObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("HealthPickupSound GameObject not found in the scene!");
        }

    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(player.currentHP <= player.HP)
            {
                player.currentHP += heal;
                eat.Play();
                Destroy(gameObject);
            } else
            {
                eat.Play();
                Destroy(gameObject);    
            }
            
        }
    }
}

