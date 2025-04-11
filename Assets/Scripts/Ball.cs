using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public float force = 1f;
    bool bouncing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Toy"))
        {
            bouncing = true; // turn on.
           
            Debug.Log("We rolling, they hatin'");
      
            hit.rigidbody.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Impulse);
            if (bouncing)
            {
                Bounclo();
            }
            bouncing = false;
           
         
        }
    }

  void Bounclo() 
    {

        force += Time.deltaTime;
      

    }


}
