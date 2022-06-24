using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    float targetZoom;
    Vector3 drag;
    private float X, Y;
    public SpriteRenderer map;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;

        X = 960;
        Y = 540;
    }
    
    // Update is called once per frame
    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData*100f;
        targetZoom = Mathf.Clamp(targetZoom, 300, 540);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 20);
        cam.transform.position = Clamp(cam.transform.position);

        if (Input.GetMouseButtonDown(1))
        {
            drag = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            cam.transform.position = Clamp(cam.transform.position + drag - cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    Vector3 Clamp(Vector3 target)
    {
        float diff = (540 - cam.orthographicSize);

        float newX = Mathf.Clamp(target.x, X - diff * 1.75f, X + diff * 1.75f);
        float newY = Mathf.Clamp(target.y, Y - diff, Y + diff);

        return new Vector3(newX, newY, target.z);
    } 
}
