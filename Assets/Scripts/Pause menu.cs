using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pause;
    bool ispaused; // an important boolean to control our functions.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(ispaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pause.SetActive(true); //turning the UI on and off. 
        Time.timeScale = 0f; // actually pausing the game.
        ispaused = true;
    }

    void ResumeGame()
    {
        pause.SetActive(false); 
        Time.timeScale = 1f;
        ispaused = false;
    }
}
