using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perroscript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public float velocidad = 30;
    public float fuerzaSalto = 30;
    private const int ANIMATION_QUIETO = 0;
 
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;
    private bool EstaSaltando = false;
    private bool EstaCorriendo=true;
    
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
         if (Input.GetKey(KeyCode.RightArrow))//Si presiono la tecla rigtharrow voy a ir hacia la derecha
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha

            }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            CambiarAnimacion(ANIMATION_CORRER);
            spriteRenderer.flipX = true;
        //}else if (Input.GetKey(KeyCode.X))
        //{
        //    CambiarAnimacion(ANIMATION_ATAQUE_ESPADA);
        }else if(Input.GetKey(KeyCode.Space)&& !EstaSaltando)
        {
                
                Saltar();
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
                EstaSaltando = true;
                EstaCorriendo = false;
        }
        else if(EstaSaltando==false)
        {
            CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
            rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
        }
    }
     private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("estado", animacion);
    }
    private void Saltar()
    {
         CambiarAnimacion(ANIMATION_SALTAR);
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }
    private void OnCollisionEnter2D(Collision2D collision){

         EstaCorriendo = true;
        EstaSaltando = false;//Cuando choca con alguna colision lo cambie mi estado a false para que pueda nuevamente saltar
        //CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
    }


}
