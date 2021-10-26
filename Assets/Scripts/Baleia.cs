using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baleinha : MonoBehaviour
{
    private void OnTriggerEnter(Collider col2D) {
        if (col2D.gameObject.CompareTag("FinalTela")){
            Destroy(this.gameObject);
        }
        
    }
}
