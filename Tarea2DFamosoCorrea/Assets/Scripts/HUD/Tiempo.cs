using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private Slider slider;

    void Update()
    {
        if (GameManager.Instance == null) return;

        float tiemporestante = GameManager.Instance.tiempoRestante;

        if (slider != null)
        {
            slider.maxValue = 60f; // total del cronómetro
            slider.value = tiemporestante;
        }

        int minutos = Mathf.FloorToInt(tiemporestante / 60);
        int segundos = Mathf.FloorToInt(tiemporestante % 60);

        if (tiempoText != null)
        {
            tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }
}