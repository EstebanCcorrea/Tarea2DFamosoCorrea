using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Arrastrar el objeto SpawnPoint en el inspector

    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);

        // Instanciar el personaje elegido en el SpawnPoint
        Instantiate(
            GameManager.Instance.personajes[indexJugador].personajeJugable,
            spawnPoint.position,
            Quaternion.identity
        );
    }
}
