using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject hero;
    
    public Vector3 respawnpoint;
   void OnTriggerEnter (Collider other)
    {
        OGPlayer player = hero.GetComponent<OGPlayer>();
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("working");
            hero.GetComponent<CharacterController>().enabled = false; //We have to turn off the CC to mannipulate its position.
            hero.transform.position = respawnpoint; // set it to the respawn position.
            player.currentHP -= 20f; // Take away that health.
            hero.GetComponent<CharacterController>().enabled = true; // turn the CC back on.
        }
    }
}
