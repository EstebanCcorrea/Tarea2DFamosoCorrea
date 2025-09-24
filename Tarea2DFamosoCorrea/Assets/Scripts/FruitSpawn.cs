using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [Header("Prefabs de frutas")]
    public GameObject cerezaPrefab;
    public GameObject kiwiPrefab;

    [Header("Configuración")]
    public int cantidadInicial = 5; // cuántas frutas colocar al inicio
    public float alturaSobreSuelo = 1f; // para que aparezcan encima del piso

    private void Start()
    {
        // Buscar todos los objetos en la capa "Floor"
        GameObject[] suelos = FindObjectsOfType<GameObject>();

        // Filtrar solo los que estén en el Layer Floor
        suelos = System.Array.FindAll(suelos, go => go.layer == LayerMask.NameToLayer("Floor"));

        // Instanciar frutas en posiciones aleatorias
        for (int i = 0; i < cantidadInicial; i++)
        {
            if (suelos.Length == 0) break;

            // Seleccionar un suelo al azar
            GameObject suelo = suelos[Random.Range(0, suelos.Length)];

            // Posición aleatoria cerca del suelo
            Vector3 pos = suelo.transform.position + Vector3.up * alturaSobreSuelo;

            // Escoger fruta aleatoria
            GameObject prefab = (Random.value < 0.5f) ? cerezaPrefab : kiwiPrefab;

            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
