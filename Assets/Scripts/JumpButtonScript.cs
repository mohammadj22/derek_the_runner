using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite sprite_on;
    public Sprite sprite_off;

    private RectTransform _rectTransform;
    private Image _image;

    private float scale;

    void Start()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.localScale = new Vector3(Screen.height/500f, Screen.height/500f, 0.01f);
        scale = _rectTransform.localScale.x;
    }
     
    public bool buttonPressed = false;
     
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_image.sprite != sprite_on) _image.sprite = sprite_on;
        _rectTransform.localScale = new Vector3(scale, scale, 0.01f);
        buttonPressed = true;
         
    }   
     
     
    public void OnPointerUp(PointerEventData eventData)
    {
        if (_image.sprite != sprite_off)  _image.sprite = sprite_off;
        _rectTransform.localScale = new Vector3(scale*1.2f, scale*1.2f, 0.01f);
 
    }   
     
 
 
}