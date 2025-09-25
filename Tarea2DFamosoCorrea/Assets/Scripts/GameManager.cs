using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Personajes> personajes;
    [Header("Contadores globales")]
    public int cerezasRecolectadas = 0;
    public int kiwisRecolectados = 0;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Suma fruta al contador global.
    /// </summary>
    public void SumarFruta(string tipoFruta)
    {
        if (tipoFruta == "Cereza")
        {
            cerezasRecolectadas++;
            Debug.Log("Cerezas: " + cerezasRecolectadas);
        }
        else if (tipoFruta == "Kiwi")
        {
            kiwisRecolectados++;
            Debug.Log("Kiwis: " + kiwisRecolectados);
        }
    }

    /// <summary>
    /// Reinicia los contadores (usado al morir o reiniciar nivel).
    /// </summary>
    public void ResetCounters()
    {
        cerezasRecolectadas = 0;
        kiwisRecolectados = 0;
        Debug.Log("Contadores reiniciados.");
    }
}
