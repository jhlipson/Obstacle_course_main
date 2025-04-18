using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public bool isGameOverScreen;
    public void PlayGame ()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You're leaving already?");
    }
    private void Update()
    {
        if (isGameOverScreen)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Main Scene");
            }
        }
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
