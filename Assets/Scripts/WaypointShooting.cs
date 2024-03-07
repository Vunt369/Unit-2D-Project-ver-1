using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;


    [SerializeField] private float speed = 4f;
    private SpriteRenderer spriteRenderer;
    private bool hasReachedEnd = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        //{
        //    currentWaypointIndex++;
        //    if (currentWaypointIndex >= waypoints.Length)
        //    {
        //        currentWaypointIndex = 0;

        //    }

        //}
        //transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * 4);

        //if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        //{
        //    // Check if reached the last waypoint
        //    if (currentWaypointIndex == waypoints.Length - 1)
        //    {
        //        hasReachedEnd = true;
        //        gameObject.SetActive(false);
        //        currentWaypointIndex--;

        //    }
        //    else if (hasReachedEnd) // Check if needs to loop back to first waypoint
        //    {
        //        currentWaypointIndex = 0;
        //        hasReachedEnd = false;


        //    }
        //    else
        //    {
        //        currentWaypointIndex++;
        //    }
        //}
        //if (!gameObject.activeInHierarchy && currentWaypointIndex == 0)
        //{
        //    gameObject.SetActive(true);
        //}

        //transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                // Cho dan ve waypoint 1
                transform.position = waypoints[0].transform.position;
                currentWaypointIndex = 0;
            }
            else
            {
                currentWaypointIndex++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
