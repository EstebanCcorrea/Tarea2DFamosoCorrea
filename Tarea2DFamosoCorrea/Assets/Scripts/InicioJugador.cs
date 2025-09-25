using UnityEngine;

public class InicioJugador : MonoBehaviour
{
  
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);
        Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, Vector3.zero, Quaternion.identity);
    }

}
