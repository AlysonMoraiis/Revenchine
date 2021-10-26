using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootSpawn : MonoBehaviour
{
     public GameObject prefab;

    public float respawnTime;

    void Update() 
    {
        respawnTime -= Time.deltaTime;
        if(respawnTime < 0)
        {
            Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            respawnTime = 1;
        }
    }
}
