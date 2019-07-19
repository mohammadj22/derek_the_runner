using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MovingPlatformsNearBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + World.GAME_SPEED*0.5f, transform.position.y, transform.position.z);
        if (transform.position.x < -100f) transform.position = new Vector3(200f, transform.position.y, transform.position.z);

    }
}
