using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    float targetZoom;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData*100f;
        targetZoom = Mathf.Clamp(targetZoom, 300, 540);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 20);
    }
}
