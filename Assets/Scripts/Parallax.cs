using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    public GameObject cameraPlayer;
    private float length, startPos;
    public float speedParallax;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - speedParallax));
        float dist = (cameraPlayer.transform.position.x * speedParallax);

        transform.position = new Vector3 (startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + length / 2)
        {
            startPos += length;
        }
        else if(temp < startPos - length / 2)
        {
            startPos -= length;
        }

    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Parallax : MonoBehaviour
// {
//     [SerializeField] private bool ignoreY;
//     [SerializeField] private float parallaxEffect;
//     private Vector3 startPos;
//     private float lenght; 
//     Transform camPos;

//     void Start()
//     {
//         startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
//         lenght = GetComponent<SpriteRenderer>().bounds.size.x;
//         camPos = Camera.main.transform;
//     }

//     void Update()
//     {
//         float temp = (camPos.transform.position.x * (1 - parallaxEffect));
//         float distance = (camPos.transform.position.x * parallaxEffect);

//         if(ignoreY)
//             transform.position = new Vector3(startPos.x + distance, startPos.y, transform.position.z);
//         else
//             transform.position = new Vector3(startPos.x + distance, transform.position.y, transform.position.z);

//         if(temp > startPos.x + lenght) startPos.x += lenght;
//         else if(temp < startPos.x - lenght) startPos.x -= lenght;
//     }
// }

