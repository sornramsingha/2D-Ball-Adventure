using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatfrom : MonoBehaviour
{
    public float moveSpeed = 2;
    public Transform[] waypoints;
    int currentWayPointIndex;

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].position, moveSpeed * Time.deltaTime);
        float d = Vector3.Distance(transform.position, waypoints[currentWayPointIndex].position);
        if (d < 0.1)
        {
            currentWayPointIndex += 1;
            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
            //currentWayPointIndex = (currentWayPointIndex + -1) % waypoints.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("is player");
            collision.transform.parent = null;
        }
    }
}