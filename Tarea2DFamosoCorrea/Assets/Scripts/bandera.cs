using TMPro;
using UnityEngine;
using System.Collections;

public class bandera : MonoBehaviour
{
    private Animator anim;
    private bool activado = false;

    [Header("UI Estadísticas")]
    [SerializeField] private GameObject panelEstadisticas;
    [SerializeField] private TextMeshProUGUI textoEstadisticas;
    [SerializeField] private float retrasoPanel = 6f; // segundos antes de mostrar el panel

    void Start()
    {
        anim = GetComponent<Animator>();

        if (panelEstadisticas != null)
            panelEstadisticas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activado && collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null && GameManager.Instance.FrutasRestantes() == 0)
            {
                activado = true;

                // Guardar tiempo del nivel actual
                GameManager.Instance.RegistrarTiempoActual();

                // Pausar solo el cronómetro (no el movimiento del jugador)
                GameManager.Instance.DetenerReloj();

                // Animación de la bandera
                if (anim != null)
                    anim.SetTrigger("Activar");

                // Esperar y mostrar panel
                StartCoroutine(MostrarPanelConRetraso());
            }
            else
            {
                Debug.Log("Aún quedan frutas, no puedes activar la bandera.");
            }
        }
    }

    private IEnumerator MostrarPanelConRetraso()
    {
        yield return new WaitForSecondsRealtime(retrasoPanel);

        if (panelEstadisticas == null || textoEstadisticas == null) yield break;

        // Preparar estadísticas
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

        // Activar panel
        panelEstadisticas.SetActive(true);

        Debug.Log(resultado);
    }
}
