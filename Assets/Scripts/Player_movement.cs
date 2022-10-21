using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private  Rigidbody2D rBody;
    public float speed = 5.5f;
    private float horizontal;
    public Animator animatronix;
    public float jumpforce = 5f;
    public float dirx;
    public bool tocaSuelo;
    public Transform trans;

    private void Awake()
    {
        
        rBody = GetComponent<Rigidbody2D>();
        animatronix = GetComponent<Animator>();
        trans = GetComponent<Transform>();

    }

   
    private void FixedUpdate() {

        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rBody.velocity = new Vector2 (dirx * speed, rBody.velocity.y);    

    }
 
    //Update is called once per frame
    void Update()
    {
        
         dirx = Input.GetAxisRaw("Horizontal");
        
        Debug.Log(dirx);

       /* transform.position += new Vector3(dirx, 0, 0) * speed * Time.deltaTime;*/

         if(dirx == -1)
        {
            //renderer.flipX = true;
            trans.rotation = Quaternion.Euler(0,180,0);
            animatronix.SetBool("Running", true);
        }
        else if(dirx == 1)
        {
            //renderer.flipX = false;
            trans.rotation = Quaternion.Euler(0,0,0);
            animatronix.SetBool("Running", true);
        }
        else
        {
            animatronix.SetBool("Running", false);
        }
        
        if(Input.GetButtonDown("Jump") && tocaSuelo) 
        {

            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); 
            animatronix.SetBool("Salto", true);

        }
        
    }
}