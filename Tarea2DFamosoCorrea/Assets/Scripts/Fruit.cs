using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Collect()
    {
        // Dispara la animación de recolección
        anim.SetTrigger("Collect");
    }

    // Este método lo llamará un evento en la animación al final
    public void DestroyFruit()
    {
        Destroy(gameObject);
    }
}
