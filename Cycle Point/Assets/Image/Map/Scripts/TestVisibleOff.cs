using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVisibleOff : MonoBehaviour
{
    SpriteRenderer rend;
    void Start()
    {
        rend = this.GetComponent<SpriteRenderer> ();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rend.enabled = !rend.enabled;
        }
    }
}
