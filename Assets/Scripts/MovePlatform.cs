using Unity.VisualScripting;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool isonX;
    public bool isonY;  
    public bool isonZ;  
    public float speed = 1f;
    public float threshold = 10f;
    private float initialXposition;
    private float initialYposition;
    private float initialZposition;
    private bool flip;
    private float targetXposition;
    private float targetYposition;  
    private float targetZposition;  
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialXposition = transform.position.x;
        targetXposition = initialXposition;
        initialYposition = transform.position.y;    
        initialZposition = transform.position.z;    
        targetYposition = initialYposition;
        targetZposition = initialZposition; 
        flip = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(isonX)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetXposition, transform.position.y, transform.position.z), speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - targetXposition) < 0.1f)  // Small threshold to avoid jitter
            {
                ToomuchX();  // Switch direction when the target is reached
            }
        }
        
        if (isonY)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetYposition, transform.position.z), speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.y - targetYposition) < 0.1f)  // Small threshold to avoid jitter
            {
                ToomuchY();  // Switch direction when the target is reached
            }
        }

        if (isonZ)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetZposition), speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.z - targetZposition) < 0.1f)  // Small threshold to avoid jitter
            {
                ToomuchZ();  // Switch direction when the target is reached
            }
        }
      
    }

    void ToomuchX()
    {
        // Flip direction
        flip = !flip;

        // Update the target position
        if (flip)
        {
            targetXposition = initialXposition - threshold;  // Move to the left
        }
        else
        {
            targetXposition = initialXposition + threshold;  // Move to the right
        }
    }

    void ToomuchY()
    {
        // Flip direction
        flip = !flip;

        // Update the target position
        if (flip)
        {
            targetYposition = initialYposition - threshold;  // Move to the down
        }
        else
        {
            targetYposition = initialYposition + threshold;  // Move to the up
        }
    }

    void ToomuchZ()
    {
        // Flip direction
        flip = !flip;

        // Update the target position
        if (flip)
        {
            targetZposition = initialZposition - threshold;  // Move to the left
        }
        else
        {
            targetZposition = initialZposition + threshold;  // Move to the right
        }
    }
}
