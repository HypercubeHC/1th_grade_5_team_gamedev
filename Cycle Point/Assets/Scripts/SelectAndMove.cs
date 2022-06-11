using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndMove : MonoBehaviour
{
    private Ray ray;
    private RaycastHit2D hit;
    public bool select = false;
    bool move = false;
    private Vector3 targetPos;
    public float speed = 2f;
    public GameObject go;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            
            if (hit.collider != null && hit.collider.gameObject == go)
            {
                select = true;
            }
            else if (hit.collider != null && hit.collider.gameObject.CompareTag("Person"))
            {
                select = false;
            }
            else if (hit.collider != null && select && hit.collider.gameObject.CompareTag("Scheme"))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.z = transform.position.z;
                move = true;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            select = false;
        }

        if (move) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
            if (transform.position == targetPos) move = false;
        }
    }
}
