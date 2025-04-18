using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    public TimeKeeper timekeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeKeeper timekeeper = GameObject.FindGameObjectWithTag("Manager").GetComponent<TimeKeeper>();
        timekeeper.Reset();
        SceneManager.LoadScene("GAME OVER"); 
    }

    
}
