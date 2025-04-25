using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wincondition : MonoBehaviour
{
    public Enemy Enemy;
    public GameObject Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy = FindFirstObjectByType<Enemy>(); 
        Text.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy == null)
        {
            Text.SetActive(true);
            if (Input.GetButtonDown("Jump")) SceneManager.LoadScene("Main scene");
        }
    }
}
