using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    [Header("Panel de Pausa")]
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(""); // Cambia "Menu" por el nombre exacto de tu escena principal
    }
}
