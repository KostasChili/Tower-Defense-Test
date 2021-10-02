
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //with static you dont need a referense to access the script. You can access it from anywhere

    public static Transform[] wayPoints;

    private void Awake()
    {
        //get number of children under waypoints
        wayPoints = new Transform[transform.childCount];
        for (int i=0;i<wayPoints.Length;i++)
        {
           //we make an array that contains all waypoints
           wayPoints[i]= transform.GetChild(i);
        }
    }
}
