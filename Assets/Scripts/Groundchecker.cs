using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundchecker : MonoBehaviour
{
 public static bool tocaSuelo;
     public Player_movement player;
     

    void Awake()
    {
         player = GameObject.Find("idle1").GetComponent<Player_movement>();
         
    }

     void OnTriggerStay2D(Collider2D col)
    {
         if(col.gameObject.tag == "grrround")
         {
        player.tocaSuelo = true;
        player.animatronix.SetBool("Salto", false);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)

    {
         player.tocaSuelo = false;
    }
}
