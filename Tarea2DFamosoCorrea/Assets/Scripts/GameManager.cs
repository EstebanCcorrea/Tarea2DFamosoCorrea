using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Contadores globales")]
    public int cerezasRecolectadas = 0;
    public int kiwisRecolectados = 0;

    private void Awake()
    {
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
}
