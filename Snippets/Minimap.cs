using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points;
    private LineRenderer line;
    int numPoints;
    public int mapHeight;
    void Awake()
    {
        points = GameObject.FindGameObjectsWithTag("Waypoint");
        line = GetComponent<LineRenderer>();
        numPoints = points.Length;
        line.positionCount = numPoints + 1;
        

        

        for(int i = 0; i < numPoints; i++ )
        {
            line.SetPosition(i, new Vector3(points[i].transform.position.x, mapHeight, points[i].transform.position.z));
        }
        line.SetPosition(numPoints, line.GetPosition(0));
        line.startWidth = 20f;
        line.endWidth = 20f;
    }

    void Update()
    {
       
    }
}
