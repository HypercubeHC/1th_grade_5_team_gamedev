using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject circle;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        circle = GameObject.Find("Image");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //if radius(!!!!!!!!!!!!!)//TODO:: zalupa
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(eventData.delta);
        
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        /*Debug.Log("x: ");
        Debug.Log(circle.transform.position.x);
        Debug.Log("y: ");
        Debug.Log(circle.transform.position.y);*/
        /*var x = rectTransform.anchoredPosition.x;
        var y = rectTransform.anchoredPosition.y;
        Debug.Log(x);
        Debug.Log(y);
        if (x is > -22 and < 22 && y is > -28 and < 22)
        {
            Debug.Log(eventData.delta);
            Debug.Log("Success");
            /*eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                Vector2(0,0);
        }*/
    }
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
       //Debug.Log("OnPointerDown");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
