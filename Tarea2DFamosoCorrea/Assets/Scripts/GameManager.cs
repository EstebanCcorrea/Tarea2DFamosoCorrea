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

    [Header("Tiempos por nivel")]
    public List<float> tiemposNiveles = new List<float>();
    private float tiempoInicial;
    private Tiempo tiempoScript;

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
        if (sigNivObj != null) sigNivObj.SetActive(true);

        tiempoScript = Object.FindFirstObjectByType    <Tiempo>();
        if (tiempoScript != null)
        {
            tiempoInicial = tiempoScript.tiemporestante;
        }
    }

    private void Update()
    {
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
    }

    public void RegistrarTiempoNivel()
    {
        if (tiempoScript != null)
        {
            float tiempoRestante = tiempoScript.tiemporestante;
            float tiempoDemorado = tiempoInicial - tiempoRestante;
            tiemposNiveles.Add(tiempoDemorado);
            Debug.Log($"Nivel {tiemposNiveles.Count} completado en {tiempoDemorado} segundos");
        }

        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }
}
