using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    public GameObject otherController;

    void OnMouseDown()
    {
        otherController.GetComponent<Caixa>().enabled = false;
        GetComponent<Player>().enabled = true;
    }
}
