using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class PlatformGenerator : MonoBehaviour
{
    
    public Queue<GameObject> PrefabsQueue = new Queue<GameObject>(16);
    public List<GameObject> Prefabs = new List<GameObject>(10);
    public Transform CameraLeftTransform;
    public Transform CameraRightTransform;

    private int _prefabIndex = 0;

    
    
    private void OnEnable()
    {
        
        foreach (var prefab in Prefabs)
        {
            PrefabsQueue.Enqueue(prefab);
        }
        Prefabs.Clear();
 
        
        
        for (int i = 0; i < 10; i++)
        {
            Random rand = new Random();
            var a = rand.Next(0,2);

            Prefabs.Add(Instantiate(Prefabs[a], new Vector3(0, 0, 0), Quaternion.identity));
        }
        
        foreach (var prefab in Prefabs)
        {
            PrefabsQueue.Enqueue(prefab);
        }

       

        Debug.Log(PrefabsQueue.Count);
    }

    void Start()
    {
 
    }

    void Update()
    {
        var first_prefab = PrefabsQueue.First();
        var first_prefab_x_size = Utilities.GetObjectXSize(first_prefab);
        if (HasCameraPastPrefab(PrefabsQueue.First(), first_prefab_x_size, CameraLeftTransform.position.x))
        {
            first_prefab = PrefabsQueue.Dequeue();

            var furthest_prefab = PrefabsQueue.Last();
            var furthest_prefab_x_size = Utilities.GetObjectXSize(furthest_prefab);
            var furthest_prefab_x_position = furthest_prefab.transform.position.x;

            PutThePastPrefabToTheFurthestPosition(first_prefab, furthest_prefab_x_position,
                furthest_prefab_x_size
                , first_prefab_x_size);
            PrefabsQueue.Enqueue(first_prefab);
        }           
    }

    private bool HasCameraPastPrefab(GameObject gameObject, float prefab_x_size, float camera_left_x_position)
    {
        return gameObject.transform.position.x + prefab_x_size / 2f < camera_left_x_position;
    }

    private void PutThePastPrefabToTheFurthestPosition(GameObject first_prefab, float  furthest_prefab_x_position,
        float furthest_prefab_x_size, float first_prefab_x_size)
    {
        var transform = first_prefab.transform;
        transform.position = new Vector3
            (furthest_prefab_x_position + furthest_prefab_x_size/2f + first_prefab_x_size/2f -0.2f, transform.position.y,
            transform.position.z);
    }
} 
