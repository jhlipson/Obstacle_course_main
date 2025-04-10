using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (rb != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Start Scene");
            }
        }
    }
}
