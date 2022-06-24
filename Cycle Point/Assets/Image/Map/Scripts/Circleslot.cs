using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Circleslot : MonoBehaviour, IDropHandler
{
    public bool check = false;
    public bool temp;
    private void Awake()
    {
        check = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            var position = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
            if (position.x is > -22 and < 22 && position.y is > -28 and < 22)
            {
                //Debug.Log(eventData.delta);
                //Debug.Log("Success");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
                check = true;
            }
            else
            {
                //Debug.Log("Failure");
                check = false;
            }
        }
    }
}