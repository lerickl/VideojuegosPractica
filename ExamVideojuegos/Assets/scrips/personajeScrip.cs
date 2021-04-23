using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeScrip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public float velocidad = 20;
    private const int ANIMATION_QUIETO = 0;
 
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;
    public GameObject rightkunai;
    public GameObject leftkunai;
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
        if(Input.GetKeyDown(KeyCode.X))
        {
           
            if(!spriteRenderer.flipX)
            {
                var position= new Vector2(transform.position.x + 2.5f, transform.position.y-.5f);
                Instantiate(rightkunai,position, rightkunai.transform.rotation);
                 

            }else {
                var position= new Vector2(transform.position.x - 2.5f, transform.position.y-.5f);
                Instantiate(leftkunai,position, leftkunai.transform.rotation);
                 
            }
       
                
      
        }
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
        }else if(Input.GetKey(KeyCode.Space))
        {

        }
        else
        {
            CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
            rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
        }
    }
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    
}
