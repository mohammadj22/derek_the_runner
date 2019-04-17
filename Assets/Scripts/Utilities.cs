using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public static float GetObjectXSize(GameObject gameObject)
    {
        var game_object_x_size = 0f;
        try
        {
            game_object_x_size = gameObject.GetComponent<Collider2D>().bounds.size.x;
        }
        catch (Exception e)
        {
            try
            {
                game_object_x_size = gameObject.GetComponent<Collider2D>().bounds.size.x;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        return game_object_x_size;
    }
 
}
