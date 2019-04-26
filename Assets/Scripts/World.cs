using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;


public class World : MonoBehaviour
{

    public static float GAME_SPEED = -0.6f;
    
    public GameObject Coin;
    public GameObject groundPlatformObject;

    private int counter;

    private Random rand;
    
    
    void Start()
    {
        counter = 0;
        rand = new Random();

    }

    void Update()
    {
        if (counter > 0) counter--;
        if (counter != 0) return;

        GAME_SPEED -= 0.0011f;
        Debug.Log(GAME_SPEED);
        int temp = rand.Next(0, 15);
        
        if (temp < 2) generateCoin();
        else if (temp < 3) generateObject();

    }


    void generateCoin()
    {
        int temp2 = rand.Next(0, 3);
        
        if (temp2 == 0) Instantiate(Coin , new Vector3(35, 4f, 0), Quaternion.identity);
        else if (temp2 == 1) Instantiate(Coin , new Vector3(35, 8f, 0), Quaternion.identity);
        else Instantiate(Coin , new Vector3(35, 12f, 0), Quaternion.identity);
        counter = 35;

    }    
    
    void generateObject()
    {

        Instantiate(groundPlatformObject , new Vector3(35, 2.5f, 0), Quaternion.identity);
        counter = 35;

    }
}
