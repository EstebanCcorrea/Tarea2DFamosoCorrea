using UnityEngine;

public class Parallax : MonoBehaviour
{
    

    public float parallaxMultipler = 0.1f;

    private Material parallaxMaterial;
    private Transform player;
    private float lastPlayerX;


    void Start()
    {
        parallaxMaterial = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerX = player.position.x;

    }

 
    void Update()
    {
        
        float deltaX = player.position.x - lastPlayerX;
        parallaxMaterial.mainTextureOffset += new Vector2(deltaX * parallaxMultipler, 0);
        lastPlayerX = player.position.x;
    }
}
