using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Respawn respawn;
    public Transform spawn;

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {


            respawn.respawnpoint = spawn.position; // We change the respawn point depending on if the player has triggered it.
        }

    }
    
}
