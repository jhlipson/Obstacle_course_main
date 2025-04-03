using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject End;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            End.SetActive(true); // We are activating the ending gameobject that will mannipulate the cameras needed to get a good look at the player.
        }
    }
}
