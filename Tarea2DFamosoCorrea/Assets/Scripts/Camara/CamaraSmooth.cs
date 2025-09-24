using UnityEngine;

public class CamaraSmooth : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá
    public float smoothSpeed = 0.125f; // La velocidad de suavizado
    public Vector3 offset; // El desplazamiento desde el objetivo




    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // La posición deseada de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Suaviza la transición
        transform.position = smoothedPosition; // Actualiza la posición de la cámara
        transform.LookAt(target); // Opcional: La cámara siempre mira al objetivo
    }

}
