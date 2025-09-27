using UnityEngine;
using TMPro;

public class EstadisticasTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panelEstadisticas;
    [SerializeField] private TextMeshProUGUI textoEstadisticas;

    private void Start()
    {
        if (panelEstadisticas != null)
            panelEstadisticas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MostrarEstadisticas();
        }
    }

    private void MostrarEstadisticas()
    {
        if (panelEstadisticas == null || textoEstadisticas == null) return;

        panelEstadisticas.SetActive(true);

        var tiempos = GameManager.Instance.tiemposNiveles;
        float suma = 0f;
        string resultado = "";

        for (int i = 0; i < tiempos.Count; i++)
        {
            resultado += $"Nivel {i + 1}: {tiempos[i]:0.00} seg\n";
            suma += tiempos[i];
        }

        resultado += $"Total: {suma:0.00} seg";

        textoEstadisticas.text = resultado;
        Debug.Log(resultado);
    }
}