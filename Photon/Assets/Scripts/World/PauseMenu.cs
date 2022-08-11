using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUi;
<<<<<<< Updated upstream
   

    private void Awake()
    {
        source = "SniperShot.wav";
    }
=======
<<<<<<< Updated upstream
   

  
=======
 

>>>>>>> Stashed changes
>>>>>>> Stashed changes
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
<<<<<<< Updated upstream
                
=======
<<<<<<< Updated upstream
                
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
            }
        }
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
<<<<<<< Updated upstream
       

=======
<<<<<<< Updated upstream
       

=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu!");
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}