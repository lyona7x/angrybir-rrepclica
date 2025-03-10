using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool ispressed= false;
    public Rigidbody2D rb;
    public Rigidbody2D DragPoint;
    public SpringJoint2D springJoint2D;
    private float dragRelaseTime = 0.15f;
    private float maxDragDistance = 2f;
    private Transform playerTransform;
    bool isJumped;
    void Start()
    {
        Time.timeScale=1;
        playerTransform = gameObject.transform;
        isJumped = false;
        Debug.Log(playerTransform.position.x);
    }

    void Update()
    {
        if (ispressed)
        {
            Vector2 mousPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousPos,DragPoint.position)> maxDragDistance)
            {
                rb.position = DragPoint.position + (mousPos -DragPoint.position).normalized *maxDragDistance;
            }
            else
            {
                rb.position= mousPos;
            }
        }

        if(transform.position.x>10)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            transform.position = new Vector2(-6,0.5f);
            springJoint2D.enabled = true;
             gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }

    }

    void OnMouseDown()
    {
        ispressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        ispressed = false;
        rb.isKinematic = false;
        StartCoroutine(RelaseDrag());
        isJumped = false;
    }

    IEnumerator RelaseDrag ()
    {
        yield return new WaitForSeconds(dragRelaseTime);
        springJoint2D.enabled = false;
        
    }
}
