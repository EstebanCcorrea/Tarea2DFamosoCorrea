using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    [SerializeField]public float speed;
    private Rigidbody2D rb2D;

    private float move;

    public float jumpforce = 4;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move*speed, rb2D.linearVelocity.y);

        if(move !=0 )
            transform.localScale = new Vector3(Mathf.Sign(move),1,1);
        if(Input.GetButtonDown("Jump") && isGrounded)
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpforce);

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        anim.SetBool("IsGrounded", isGrounded);

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kiwi") || collision.CompareTag("Cereza"))
        {
            Fruit fruta = collision.GetComponent<Fruit>();
            if (fruta != null)
            {
                fruta.Collect();
            }
        }
    }
}