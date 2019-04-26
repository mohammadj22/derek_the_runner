using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;



public class PlatformScript : MonoBehaviour
{
    public Sprite sprite_1;
    public Sprite sprite_2;
    public Sprite sprite_3;

    private Random rand;

    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        rand = new Random();

        int temp = rand.Next(0, 3);

        if (temp == 0) _spriteRenderer.sprite = sprite_1;
        else if (temp == 1)_spriteRenderer.sprite = sprite_2;
        else _spriteRenderer.sprite = sprite_3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + World.GAME_SPEED, transform.position.y, transform.position.z);
        if (transform.position.x < -50) Destroy(this.gameObject);

    }
}
