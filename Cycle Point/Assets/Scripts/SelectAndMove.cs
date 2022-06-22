using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SelectAndMove : MonoBehaviour
{
    private Ray ray;
    private RaycastHit2D hit;
    public bool select = false;
    bool move = false;
    private Vector3 targetPos;
    private float speed = 1250f;
    public GameObject go;

    Path path;
    int currentPoint = 0;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentPoint = 0;
        }
    }

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
                AstarPath.active.Scan();
                seeker.StartPath(rb.position, targetPos, OnPathComplete);
                //move = true;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            select = false;
        }

        //if (move) 
        //{
        //    transform.position = vector3.movetowards(transform.position, targetpos, speed*time.deltatime);
        //    if (transform.position == targetpos) move = false;
        //}
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentPoint >= path.vectorPath.Count)
        {
            move = false;
            return;
        }
        else
        {
            move = true;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentPoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;
        rb.AddForce(force);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentPoint]);

        if (dist < 3f)
        {
            currentPoint++;
        }
    }
}
