using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;


public class World : MonoBehaviour
{

    public GameObject Coin;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        var rand = new Random();

        int temp = rand.Next(0, 5);

        if (temp == 0)
        {
            Instantiate(Coin , new Vector3(35, 4f, 0), Quaternion.identity);

        }
        
    }
}
