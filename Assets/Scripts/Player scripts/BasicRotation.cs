using UnityEngine;
using UnityEngine.UIElements;

public class BasicRotation : MonoBehaviour
{
    public float speed = 5f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(Vector3.down * speed * Time.deltaTime); 
        } 
      
    }

   
}
