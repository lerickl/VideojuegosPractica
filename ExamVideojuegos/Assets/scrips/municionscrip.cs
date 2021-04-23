using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionscrip : MonoBehaviour
{
    public float velocityx=30f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right*velocityx;
    }
}
