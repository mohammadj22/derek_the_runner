using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private SkeletonAnimation _skeletonAnimation;  

    void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    void Update()
    {
        if (_skeletonAnimation.AnimationName != "Attack") 
            _skeletonAnimation.state.SetAnimation(0, "Attack", true).TimeScale = 0.5f;
        transform.position = new Vector3(transform.position.x + World.GAME_SPEED, transform.position.y, transform.position.z);
        if (transform.position.x < -50) Destroy(this.gameObject);
    }
}
