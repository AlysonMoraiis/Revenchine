using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBaleia : MonoBehaviour
{
    public GameObject prefab;

    private float respawnTimePv;
    public float respawnTime;

    void Update() 
    {
        respawnTimePv -= Time.deltaTime;
        if(respawnTimePv < 0)
        {
            Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            respawnTimePv = respawnTime;
        }
    }
}
