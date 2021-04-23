 
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invoGameObject : MonoBehaviour
{
    public GameObject zombi;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnobject",1);
    }
    void spawnobject()
    {
        var posicion = new Vector2(transform.position.x+1f,transform.position.y-.1f);
        Instantiate(zombi,posicion,zombi.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
