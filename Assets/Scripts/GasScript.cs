using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasScript : MonoBehaviour
{

    private Animator _animator;
    private SpriteRenderer _renderer;
    public Sprite LastSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer.sprite == LastSprite)
        {
            Destroy(this.gameObject);
        }
    }
}
