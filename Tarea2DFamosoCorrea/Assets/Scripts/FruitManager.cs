using UnityEngine;
using TMPro;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cerezaText;
    [SerializeField] private TextMeshProUGUI kiwiText;

    void Update()
    {
        cerezaText.text = "" + GameManager.Instance.cerezasRecolectadas;
        kiwiText.text = "" + GameManager.Instance.kiwisRecolectados;
    }
}
