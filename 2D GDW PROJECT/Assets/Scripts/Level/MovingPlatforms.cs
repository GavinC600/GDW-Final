using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] int speed;

    PlayerController player;

    int num;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    
    void Update()
    {
        //checks if the distance between the platform and waypoint is 0
        if (Vector2.Distance(waypoints[num].transform.position, transform.position) == 0)
        {
            num++;
            if (num >= waypoints.Length)
            {
                num = 0;
            }
        }
        //moves the platform to the waypoint at num
        transform.position = Vector2.MoveTowards(transform.position, waypoints[num].transform.position, Time.deltaTime * speed);
    }
}