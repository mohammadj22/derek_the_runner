using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public Transform derekTransform;
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x + World.GAME_SPEED, transform.position.y, transform.position.z);
        if (transform.position.x < -50) Destroy(this.gameObject);
    }
}
