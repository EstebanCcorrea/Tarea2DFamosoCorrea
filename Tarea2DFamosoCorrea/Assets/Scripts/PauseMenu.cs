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
        if (pausePanel == null)
        {
            Debug.LogError(" PauseMenu: No se asignó el PausePanel en el Inspector.");
        }
        else
        {
            pausePanel.SetActive(false);
        }
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
        isPaused = false;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetCounters(); // reinicia contadores y tiempo
        }

        // Ir siempre a la primera escena de juego
        SceneManager.LoadScene("Scene1"); // cambia "Scene1" por el nombre real de tu escena inicial
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        // Destruir el GameManager persistente para empezar de cero
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetCounters(); // limpia contadores y tiempo
        }
        SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre exacto de tu escena principal
    }
}
