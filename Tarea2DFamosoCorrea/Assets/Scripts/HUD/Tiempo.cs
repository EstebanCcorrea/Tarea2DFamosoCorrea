using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private Slider slider;

    [Header("Tiempo de juego")]
    public float tiemporestante = 90f; // pública para que otros scripts puedan leerla

    void Start()
    {
        if (slider != null)
        {
            slider.maxValue = tiemporestante;
            slider.value = tiemporestante;
        }
    }

    void Update()
    {
        if (tiemporestante > 0)
        {
            tiemporestante -= Time.deltaTime;

            if (slider != null)
            {
                slider.value = tiemporestante;
                slider.enabled = false;
            }
        }
        else if (tiemporestante < 0)
        {
            tiemporestante = 0;
        }

        if (tiempoText != null)
        {
            int minutos = Mathf.FloorToInt(tiemporestante / 60);
            int segundos = Mathf.FloorToInt(tiemporestante % 60);
            tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }
}