using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class seleccionpersonajes : MonoBehaviour
{
    private int index;
    [SerializeField] private Image Imagen;
    [SerializeField] private TextMeshProUGUI Nombre;
    private GameManager gameManager;



    private void Start()
    {
        gameManager = GameManager.Instance;
        index = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);
        
        if (index > gameManager.personajes.Count - 1)
        {
            index = 0;  
        }
        CambiarPantalla();
    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("PersonajeSeleccionado", index);
        Imagen.sprite = gameManager.personajes[index].imagen;
        Nombre.text = gameManager.personajes[index].nombrePersonaje;
    }

    public void Siguiente()
    {
      
        if (index == gameManager.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarPantalla();
    }
    public void Anterior()
    {

        if (index == 0)
        {
            index = gameManager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarPantalla();
    }

    public void InicioJuego()
    {
        SceneManager.LoadScene("Scene1");
    }

}
