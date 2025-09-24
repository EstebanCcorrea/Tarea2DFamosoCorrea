using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tiempoText;
    [SerializeField] float tiemporestante;
    [SerializeField] private Slider slider;


    void Start()
    {
        slider.maxValue = tiemporestante;
        slider.value = tiemporestante;
    }

    void Update()
    {

        if (tiemporestante > 0)
        {
            tiemporestante -= Time.deltaTime;
            slider.value = tiemporestante; slider.enabled = false;

        }
        else if (tiemporestante < 0)
        {
            tiemporestante = 0;
            // Aquí puedes agregar la lógica para cuando el tiempo se agote
            // Por ejemplo, detener el juego, mostrar un mensaje, etc.
        }



        int minutos = Mathf.FloorToInt(tiemporestante / 60);
        int segundos = Mathf.FloorToInt(tiemporestante % 60);
        tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);

    }



}