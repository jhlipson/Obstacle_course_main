using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject cube;
    Player player;
    CharacterController cc;
    Showforce showforce;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        player = GetComponent<Player>();    
        showforce = FindFirstObjectByType<Showforce>(); 
    }



    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject == cube)
        {
            showforce.Boom(true);
        }
    }
}
