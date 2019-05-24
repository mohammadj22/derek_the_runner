using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Spine.Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Object = System.Object;

public class PlayerPhysics : MonoBehaviour
{

    public float jumpSpeed = 0.3f;
    public int sliding = 0;
    public int attacking = 0;


    
    
    public Transform groundCheck;
    public Transform coinCheck;
    public LayerMask groundLayer;
    public LayerMask coinLayer;
    public LayerMask platformLayer;
    public LayerMask enemyLayer;
    public int coins;
    public Text score;
    public Button attackButton;
    private AttackButtonScript attackButtonScript;
    private SkeletonAnimation _skeletonAnimation;
    private BoxCollider2D _boxCollider;



    private float _verticalSpeed;
    private string _animationState;
    
    
    private const string JUMP_ANIMATION = "jump";
    private const string SLIDE_ANIMATION = "slide";
    private const string RUN_ANIMATION = "idle";
    private const string ATTACK_ANIMATION = "Attack_Sword";
        
    
    
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _boxCollider = GetComponent<BoxCollider2D>();
        attackButtonScript = attackButton.GetComponent<AttackButtonScript>();
        

        
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // inits //
        var pos = transform.position;
        if (!IsGrounded() && sliding > 0) sliding = 30;
        if (sliding > 0) sliding -= 1;
        if (attacking > 0) attacking -= 1;
        foundCoin();
        collisionCheck();
        enemyCheck();
        
        // collider set //
        if (sliding > 0)
        {
            _boxCollider.size = new Vector2(5, 5);
            _boxCollider.offset = new Vector2(0, 2.5f);
        }
        else
        {
            _boxCollider.size = new Vector2(5, 10);
            _boxCollider.offset = new Vector2(0, 5);
        }
        
        // set coin-check position //
        coinCheck.transform.position = new Vector3(pos.x, pos.y + _boxCollider.size.y/2, pos.z);
        
        
        // gravity //
        _verticalSpeed -= 0.05f;
        if (IsGrounded()) _verticalSpeed = 0;
        
        
        // inputs //

        // attack //
        if (attackButtonScript.buttonPressed)
        {
            attackButtonScript.buttonPressed = false;
            if (sliding > 0) sliding = 0;
            attacking = 15;

        }
        
        // jump //
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Rect rect = new Rect(Screen.width/2f, 0, Screen.width, Screen.height);
            if (rect.Contains(touch.position) && touch.phase == TouchPhase.Began && CanJump())
            {
                if (sliding > 0) sliding = 0;
                if (attacking > 0) attacking = 0;
                _verticalSpeed = jumpSpeed;
            }
        }
        else if (CanJump() && Input.GetKeyDown("space"))
        {
            if (sliding > 0) sliding = 0;
            if (attacking > 0) attacking = 0;
            _verticalSpeed = jumpSpeed;
            
        }
        
        // slide //
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Debug.Log("1");
            Rect rect = new Rect(0, 0, Screen.width/2f, Screen.height);
            if (rect.Contains(touch.position) && touch.phase == TouchPhase.Began && CanSlide())
            {
                Debug.Log("2");

                if (attacking > 0) attacking = 0;
                sliding = 30;
            }
        }
        else if (CanSlide() && Input.GetKeyDown(KeyCode.S))
        {
            if (attacking > 0) attacking = 0;
            sliding = 30;
        }
        
        
        // vertical movement
        transform.position = new Vector3(pos.x, pos.y + _verticalSpeed, pos.z);
        
        
        // animation state //
        if    (attacking > 0)   _animationState = ATTACK_ANIMATION;
        else if    (!IsGrounded()) _animationState = JUMP_ANIMATION;
        else if    (sliding > 0) _animationState = SLIDE_ANIMATION;
        else                         _animationState = RUN_ANIMATION;
    
        
        
        // animation set //
        switch (_animationState)
        {
            case ATTACK_ANIMATION:
                if (_skeletonAnimation.AnimationName != ATTACK_ANIMATION)
                    _skeletonAnimation.state.SetAnimation(0, ATTACK_ANIMATION, true);
                break;
            
            case JUMP_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Jump") 
                    _skeletonAnimation.state.SetAnimation(0, "Jump", true).TimeScale = 0.8f;
                break;
            
            case SLIDE_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Slide_In") 
                    _skeletonAnimation.state.SetAnimation(0, "Slide_In", true);
                break;
            
            case RUN_ANIMATION:
                if (_skeletonAnimation.AnimationName != "Run")
                    _skeletonAnimation.state.SetAnimation(0, "Run", true);
                break;            
            

        }
    }

    bool CanJump()
    {
        if (IsGrounded()) return true;
        return false;

    }

    bool CanSlide()
    {
        if (sliding > 0) return false;
        if (_verticalSpeed < 0) return true;
        if (IsGrounded()) return true;
        return false;
    }
    
    bool CanAttack()
    {
        return true;
        //if (IsGrounded()) return true;
        //return false;
    }


    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    void foundCoin()
    {
        var Coins = Physics2D.OverlapCircleAll(coinCheck.position, 2f, coinLayer).ToList();
        foreach (var coin in Coins)
        {
            coins += 1;
            Destroy(coin.gameObject);
            score.text = "Coins: " + coins;
        }
    }

    void collisionCheck()
    {
        if (Physics2D.OverlapCircle(coinCheck.position, 2.5f, platformLayer))
            SceneManager.LoadScene("SampleScene");        

    }
    
    void enemyCheck()
    {
        if (Physics2D.OverlapCircle(coinCheck.position, 2f, enemyLayer))
            if (attacking == 0) SceneManager.LoadScene("SampleScene");        

        var enemy = Physics2D.OverlapCircle(coinCheck.position, 3.5f, enemyLayer);
        
        if (enemy != null && attacking>0) Destroy(enemy.gameObject);

    }

    

    void touchAttack()
    {
        attacking = 15;
    }


}




