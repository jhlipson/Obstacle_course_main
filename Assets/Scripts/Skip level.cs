using UnityEngine;

public class Skiplevel : MonoBehaviour
{
    public GameObject hero;

    public Vector3 respawnpoint;
    void OnTriggerEnter(Collider other)
    {
        Player player = hero.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Oh! You skipped the level... sad.");
            hero.GetComponent<CharacterController>().enabled = false;
            hero.transform.position = respawnpoint; 
            // Similar to respawn script but just changing it to respawn at the end of the level
             // so that you can see what happens with the camera.
            hero.GetComponent<CharacterController>().enabled = true;
        }
    }
}
