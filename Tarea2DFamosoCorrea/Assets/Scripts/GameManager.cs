using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Personajes> personajes;

    [Header("Contadores globales")]
    public int cerezasRecolectadas = 0;
    public int kiwisRecolectados = 0;

    [Header("Tiempo Global")]
    [SerializeField] public float duracionTiempo = 60f; // duración total del cronómetro
    public float tiempoRestante; // cronómetro global
    private bool relojActivo = true;

    [Header("Tiempos por nivel")]
    public List<float> tiemposNiveles = new List<float>();
    private float tiempoNivelInicio;

    private GameObject sigNivObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sigNivObj = GameObject.FindGameObjectWithTag("SigNiv");
        if (sigNivObj != null)
        {
            sigNivObj.SetActive(false);
            Debug.Log("SigNiv encontrado y apagado al inicio.");
        }

        // Iniciar o pausar reloj según la escena
        if (scene.name == "Scene1" || scene.name == "Scene2") // puedes poner nombres exactos si prefieres
        {
            if (tiempoRestante <= 0) // si es la primera vez
                tiempoRestante = duracionTiempo;

            relojActivo = true;
            tiempoNivelInicio = tiempoRestante;
        }
        else
        {
            relojActivo = false; // en el menú u otras escenas
        }
    }

    private void Update()
    {
        if (relojActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                PlayerDeath();
            }
        }

        // Activar SigNiv cuando no haya frutas
        if (sigNivObj != null && !sigNivObj.activeSelf)
        {
            GameObject[] frutas = GameObject.FindGameObjectsWithTag("Cereza");
            GameObject[] kiwis = GameObject.FindGameObjectsWithTag("Kiwi");

            if (frutas.Length == 0 && kiwis.Length == 0)
            {
                sigNivObj.SetActive(true);
                Debug.Log("Todas las frutas recolectadas. Activando SigNiv.");
            }
        }
        //muerte por tiempo
        if (relojActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                PlayerDeath(); // aquí disparamos animación
            }
        }
    }

    public void SumarFruta(string tipoFruta)
    {
        if (tipoFruta == "Cereza")
        {
            cerezasRecolectadas++;
        }
        else if (tipoFruta == "Kiwi")
        {
            kiwisRecolectados++;
        }
    }

    public void ResetCounters()
    {
        cerezasRecolectadas = 0;
        kiwisRecolectados = 0;
        tiemposNiveles.Clear();
        tiempoRestante = 60f; // reiniciar reloj global
    }

    public void RegistrarTiempoNivel()
    {
        float tiempoDemorado = tiempoNivelInicio - tiempoRestante;
        tiemposNiveles.Add(tiempoDemorado);
        Debug.Log($"Nivel {tiemposNiveles.Count} completado en {tiempoDemorado} segundos");

        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }
    private void PlayerDeath()
    {
        relojActivo = false; // detener reloj
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Death"); // Trigger en el Animator del jugador
            }
        }
    }
}
