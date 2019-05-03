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
        transform.position = Vector3.MoveTowards(transform.position, derekTransform.position, 1f);
    }
}
