using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x  + World.GAME_SPEED, transform.position.y, transform.position.z);
        if (transform.position.x < -50) Destroy(this.gameObject);
    }
    
    
    
}
