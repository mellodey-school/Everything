using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{ // array of waypoints that define the path 
    public GameObject[] Waypoints;

    public Vector3 GetPosition(int index)
    {// return position of waypoint at given index
        return Waypoints[index].transform.position;
    }

    private void OnDrawGizmos()
    { // visualize waypoints and path in the editor and not the game view 
        if (Waypoints.Length > 0)
        {
            for (int i = 0; i < Waypoints.Length; i++)
            { // draw waypoint as a sphere
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.alignment = TextAnchor.MiddleCenter;
                Handles.Label(Waypoints[i].transform.position + Vector3.up * 0.7f, Waypoints[i].name, style);

                if (i < Waypoints.Length - 1)
                { // draw line to next waypoint
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(Waypoints[i].transform.position, Waypoints[i + 1].transform.position);
                }
            }
        }
    }
}
