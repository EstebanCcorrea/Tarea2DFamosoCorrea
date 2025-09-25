using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [Header("Prefabs de frutas")]
    [SerializeField] private GameObject cerezaPrefab;
    [SerializeField] private GameObject kiwiPrefab;

    [Header("Puntos de spawn predefinidos")]
    [SerializeField] private Transform[] puntosSpawn;

    [Header("Configuración")]
    [SerializeField] private int cantidadInicial = 5;
    [SerializeField] private float tiempoEntreSpawns = 10f;

    private void Start()
    {
        // Spawns iniciales
        for (int i = 0; i < cantidadInicial; i++)
        {
            SpawnFruta();
        }

        // Respawn dinámico
        if (tiempoEntreSpawns > 0)
            InvokeRepeating(nameof(SpawnFruta), tiempoEntreSpawns, tiempoEntreSpawns);
    }

    private void SpawnFruta()
    {
        if (puntosSpawn.Length == 0)
        {
            Debug.LogWarning(" No hay puntos de spawn asignados en el inspector.");
            return;
        }

        // Elegir un punto al azar
        Transform punto = puntosSpawn[Random.Range(0, puntosSpawn.Length)];

        // Elegir fruta al azar
        GameObject prefab = (Random.value < 0.5f) ? cerezaPrefab : kiwiPrefab;

        // Instanciar fruta en ese punto
        Instantiate(prefab, punto.position, Quaternion.identity);
    }
}
