using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class PlatformGenerator : MonoBehaviour
{
    
    private Queue<GameObject> _prefabsQueue = new Queue<GameObject>(16);
    private Queue<GameObject> _frontPrefabsQueue = new Queue<GameObject>(16);
    
    public List<GameObject> Prefabs = new List<GameObject>(10);
    public List<GameObject> FrontPrefabs = new List<GameObject>(10);
    
    public Transform CameraLeftTransform;
    public Transform CameraRightTransform;
    private Dictionary<String, float> _prefabSizes = new Dictionary<string, float>();
    private Dictionary<String, float> _frontPrefabSizes = new Dictionary<string, float>();
    

    private int _prefabIndex = 0;

    
    
    private void OnEnable()
    {
        
        foreach (var prefab in Prefabs)
        {
            _prefabsQueue.Enqueue(prefab);
            _prefabSizes.Add(prefab.name, Utilities.GetObjectXSize(prefab));
        }        
        
        foreach (var prefab in FrontPrefabs)
        {
            _frontPrefabsQueue.Enqueue(prefab);
            _frontPrefabSizes.Add(prefab.name, Utilities.GetObjectXSize(prefab));
        }

    }

    void Start()
    {
 
    }

    void Update()
    {
        var firstPrefab = _prefabsQueue.First();
        var firstPrefabXSize = _prefabSizes[firstPrefab.name];
        if (HasCameraPastPrefab(_prefabsQueue.First(), firstPrefabXSize, CameraLeftTransform.position.x))
        {
            firstPrefab = _prefabsQueue.Dequeue();

            var furthestPrefab = _prefabsQueue.Last();
            var furthestPrefabXSize = _prefabSizes[furthestPrefab.name];
            var furthestPrefabXPosition = furthestPrefab.transform.position.x;

            PutThePastPrefabToTheFurthestPosition(firstPrefab, furthestPrefabXPosition,
                furthestPrefabXSize
                , firstPrefabXSize);
            _prefabsQueue.Enqueue(firstPrefab);
        }     
        
        firstPrefab = _frontPrefabsQueue.First();
        firstPrefabXSize = _frontPrefabSizes[firstPrefab.name];
        if (HasCameraPastPrefab(_frontPrefabsQueue.First(), firstPrefabXSize, CameraLeftTransform.position.x))
        {
            firstPrefab = _frontPrefabsQueue.Dequeue();

            var furthestPrefab = _frontPrefabsQueue.Last();
            var furthestPrefabXSize = _frontPrefabSizes[furthestPrefab.name];
            var furthestPrefabXPosition = furthestPrefab.transform.position.x;

            PutThePastPrefabToTheFurthestPosition(firstPrefab, furthestPrefabXPosition,
                furthestPrefabXSize
                , firstPrefabXSize);
            _frontPrefabsQueue.Enqueue(firstPrefab);
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
            (furthest_prefab_x_position + World.GAME_SPEED + furthest_prefab_x_size/2f + first_prefab_x_size/2f -0.2f, transform.position.y,
            transform.position.z);
    }
} 
