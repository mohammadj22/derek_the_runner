using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsSun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + World.GAME_SPEED*0.01f, transform.position.y, transform.position.z);
    }
}
