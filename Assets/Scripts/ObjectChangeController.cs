using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeController : MonoBehaviour
{
    public GameObject otherController;

    void OnMouseDown()
    {
        otherController.GetComponent<Player>().enabled = false;
        GetComponent<Caixa>().enabled = true;
    }
}
