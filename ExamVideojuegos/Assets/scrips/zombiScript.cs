using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool EstaMuerto = false;
    private bool EstaDestruido = false;
    public float velocidad = 20;
    private const int ANIMATION_NORMAL=0;
    private const int ANIMATION_CORRER=1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EstaMuerto != true & EstaDestruido==false)
         {
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                CambiarAnimacion(ANIMATION_CORRER);
                if(velocidad<10){
                    spriteRenderer.flipX = false;
                }else{
                    spriteRenderer.flipX = true;
                }
                
         }
    }
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("estado", animacion);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        velocidad=velocidad*-1;
    }
}
