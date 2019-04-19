using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    public float jumpSpeed = 0.3f;
    public int sliding;
    
    
    public Transform groundCheck;
    public Transform coinCheck;
    public LayerMask groundLayer;
    public LayerMask coinLayer;
    
        private SkeletonAnimation _skeletonAnimation;



    private float _verticalSpeed;
    private string _animationState;
    
    
    private const string JUMP_ANIMATION = "jump";
    private const string SLIDE_ANIMATION = "slide";
    private const string RUN_ANIMATION = "idle";
        
    
    
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        // inits //
        if (sliding > 0) sliding -= 1;
        foundCoin();
        
        
        // gravity //
        _verticalSpeed -= 0.025f;
        if (IsGrounded()) _verticalSpeed = 0;
        
        
        // inputs //

        // jump //
        if (CanJump() && Input.GetKeyDown("space"))
        {
            _verticalSpeed = jumpSpeed;
        }
        
        // slide //
        if (CanSlide() && Input.GetKeyDown(KeyCode.S))
        {
            sliding = 30;
        }
        
        
        // vertical movement
        transform.position = new Vector3(transform.position.x, transform.position.y + _verticalSpeed, transform.position.z);
        
        
        // animation state //
        if         (!IsGrounded()) _animationState = JUMP_ANIMATION;
        else if    (sliding > 0) _animationState = SLIDE_ANIMATION;
        else       _animationState = RUN_ANIMATION;
        
        
        // animation set //
        switch (_animationState)
        {
            case JUMP_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Jump") _skeletonAnimation.state.SetAnimation(0, "Jump", true);
                break;
            
            case SLIDE_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Slide_In") _skeletonAnimation.state.SetAnimation(0, "Slide_In", true);
                break;
            
            case RUN_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Run") _skeletonAnimation.state.SetAnimation(0, "Run", true);
                break;
        }
    }

    bool CanJump()
    {
        if (IsGrounded() && sliding == 0) return true;
        return false;

    }

    bool CanSlide()
    {
        if (IsGrounded()) return true;
        return false;
    }


    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    void foundCoin()
    {
        var Coins = Physics2D.OverlapCircleAll(coinCheck.position, 1f, coinLayer).ToList();
        foreach (var coin in Coins)
        {
            Debug.Log(coin);
            Destroy(coin.gameObject);
        }
    }

}




