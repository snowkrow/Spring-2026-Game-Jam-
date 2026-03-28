using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Green_Lantern : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.tag == "Player")
       {
           Player_movement player = collision.gameObject.GetComponent<Player_movement>();
           player.gL += 1;
           Destroy(gameObject);
       }
   }
}
