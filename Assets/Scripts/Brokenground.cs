using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brokenground : MonoBehaviour
{

   private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "Player")
       {
           Destroy(this.gameObject, 2f);
       }
   }
}
