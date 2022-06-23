using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWall : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    { 
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + 0.9f * horizontal * Time.deltaTime;
        position.y = position.y + 0.9f * vertical * Time.deltaTime;
        transform.position = position;
    }*/
    /*float radius = 5f, angularSpeed = 0.2f;
    float positionX, positionY, angle = 0f;
    void Update()
    {
        var dx = Mathf.Cos(angle) * radius;
        var dz = Mathf.Sin(angle) * radius;
 
        transform.position = new Vector3(0, 0, 0) + new Vector3(dx, dz, 0);

        angle += Time.deltaTime * angularSpeed;
        if (angle >= 360f)
            angle -= 360f;
        
        if( Input.GetKeyDown( KeyCode.W ) )
            radius += 0.2f;
        if( Input.GetKeyDown( KeyCode.S ) )
            radius -= 0.2f;
        if( Input.GetKeyDown( KeyCode.A ) )
            angularSpeed -= 0.2f;
        if( Input.GetKeyDown( KeyCode.D ) )
            angularSpeed += 0.2f;
            
    }*/
    
}
