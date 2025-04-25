using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject blackscreen;
    bool ispaused; // an important boolean to control our functions.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause.SetActive(false);
        blackscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            
            PauseGame();
            
        }
    }

    public void PauseGame()
    {
       blackscreen.SetActive(true);
        pause.SetActive(true); //turning the UI on and off. 
        Cursor.visible = true;
        Time.timeScale = 0f; // actually pausing the game.
       
    }

   public void ResumeGame()
    {
        pause.SetActive(false); 
        Time.timeScale = 1f;
        Cursor.visible = false;
        blackscreen.SetActive(false);
    
    }
}
