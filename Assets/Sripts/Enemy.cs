
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1,10)]
    public float speed = 1f;
    public int hp = 10;

    private Transform target;
    private int waypointIndex=0; //current waypoint we are trying to get

     void Start()
    {
        target = Waypoints.wayPoints[0]; //first waypoint target
    }

    void Update()
    {
        moveEnemy();
        
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();   
        }
        
    }

    void moveEnemy()
    {
        //target position - out position gives the vector
        Vector3 direct = target.position - transform.position;
        //moves this transform to the distance and direction of the translation given from the vector 
        //delta time makes the speed irelevant of framerate
        transform.Translate(direct.normalized * speed * Time.deltaTime, Space.World);
    }
    void GetNextWaypoint()
    {
        if(waypointIndex>=Waypoints.wayPoints.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex += 1;
        target = Waypoints.wayPoints[waypointIndex];
    }
}
