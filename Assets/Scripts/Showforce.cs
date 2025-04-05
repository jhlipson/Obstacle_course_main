using UnityEngine;

public class Showforce : MonoBehaviour
{
    Rigidbody rb;
    public float leap = 10f;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
    
   public void Boom (bool bam)
    {

        if(bam)
        {
            rb.AddForce(Vector3.up * leap, ForceMode.Impulse);
        }
    }

}
