using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    public void Collect()
    {
        //  Desactivar colisión inmediatamente
        if (col != null) col.enabled = false;

        //  Disparar animación de recolección (sprite de difuminado/partículas)
        if (anim != null) anim.SetTrigger("Collect");

        //  Avisar al GameManager
        GameManager.Instance.SumarFruta(gameObject.tag);
    }

    // Este método lo llamará un evento en la animación al final
    public void DestroyFruit()
    {
        Destroy(gameObject);
    }
}
