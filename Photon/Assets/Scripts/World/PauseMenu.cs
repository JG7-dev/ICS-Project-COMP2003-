using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenu : MonoBehaviour
{
    private static bool _isPaused;
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        if (_isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        
    }
}