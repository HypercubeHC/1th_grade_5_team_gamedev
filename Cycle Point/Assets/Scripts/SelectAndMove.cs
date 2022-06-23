using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class SelectAndMove : MonoBehaviour
{
    private Ray ray;
    private RaycastHit2D hit;
    public bool select = false;
    private Vector3 targetPos;
    private float speed = 400f;
    public bool move = false;
    public GameObject go;
    public Image im;
    public bool broken = false;
    public bool isMedic = false;
    public bool isChemist = false;
    public int chance;
    GameObject[] person;

    Path path;
    int currentPoint = 0;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        person = GameObject.Find("Controller").GetComponent<GeneralController>().people;
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
                im.rectTransform.sizeDelta = new Vector2(325, 100);
            }
            else if (hit.collider != null && hit.collider.gameObject.CompareTag("Person"))
            {
                select = false;
                im.rectTransform.sizeDelta = new Vector2(270, 88);
            }
            else if (hit.collider != null && select && !broken && hit.collider.gameObject.CompareTag("Scheme"))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.z = transform.position.z;
                //AstarPath.active.Scan();
                seeker.StartPath(rb.position, targetPos, OnPathComplete);
                move = true;
            }
        }

        if (isMedic)
        {
            medic();
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

        //Vector2 dir = ((Vector2)path.vectorPath[currentPoint] - rb.position).normalized;
        // Vector2 force = dir * speed * Time.fixedDeltaTime;
        //rb.AddForce(force);
        Vector2 newPos = Vector2.MoveTowards(rb.position, path.vectorPath[currentPoint], speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentPoint]);

        if (dist < 2f)
        {
            currentPoint++;
        }
    }

    void medic()
    {
        foreach (var item in person)
        {
            if (item.activeInHierarchy && Vector2.Distance(go.transform.position, item.transform.position) < 20f)
                item.GetComponent<SelectAndMove>().broken = false;
        }
    }
}
