using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;


public class World : MonoBehaviour
{

    public static float GAME_SPEED = -0.5f;
    
    public GameObject Coin;
    public GameObject groundPlatformObject;
    public GameObject fireEnemy;
    public GameObject derekPosition;
    public GameObject enemy;
    public GameObject gas;

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

        //GAME_SPEED -= 0.0011f;
        int temp = rand.Next(0, 15);

        if (temp < 3) generateGas();

        if (temp < 2) generateCoin();
        else if (temp < 3) generateObject();
        else if (temp < 4) generateFireEnemy();
        else if (temp < 5) generateEnemy();
        
        
    }


    void generateCoin()
    {
        int temp2 = rand.Next(0, 2);
        
        if (temp2 == 0) Instantiate(Coin , new Vector3(70, 3.5f, 0), Quaternion.identity);
        else if (temp2 == 1) Instantiate(Coin , new Vector3(70, 9.5f, 0), Quaternion.identity);
        counter = 35;
    }
    
    void generateFireEnemy()
    {
        int temp2 = rand.Next(0, 2);

        if (temp2 == 0)
        {
            var t = Instantiate(fireEnemy , new Vector3(70, 1.5f, 0), Quaternion.identity);
        }else if (temp2 == 1)
        {
            var t = Instantiate(fireEnemy , new Vector3(70, 5.5f, 0), Quaternion.identity);
        }
  

        counter = 35;
    }  
    
    void generateObject()
    {

        Instantiate(groundPlatformObject , new Vector3(70, 0f, 0), Quaternion.identity);
        counter = 35;

    }    
    
    void generateEnemy()
    {

        Instantiate(enemy , new Vector3(70, -2.5f, 0), Quaternion.identity);
        counter = 35;

    }

    void generateGas()
    {
        float temp_x = rand.Next(-5, 40);
        Instantiate(gas, new Vector3(temp_x, -9.5f, 0), Quaternion.identity);
    }
}
