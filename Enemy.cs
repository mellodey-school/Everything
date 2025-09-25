using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Path currentPath;

    private Vector3 _targetPosition;
    private int _currentWaypoint;

    private void Awake()
    {// find the path in the scene
        currentPath = GameObject.Find("Path1").GetComponent<Path>();
    }

    private void OnEnable()
    { // reset to first waypoint
        _currentWaypoint = 0;
        _targetPosition = currentPath.GetPosition(_currentWaypoint);
    }

    void Update()
    {
        // move towards target position
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);

        // when target reached, set new target position
        float relativeDistance = (transform.position - _targetPosition).magnitude;
        if (relativeDistance < 0.1f)
        {
            if (_currentWaypoint < currentPath.Waypoints.Length - 1)
            {// move to next waypoint
                _currentWaypoint++;
                _targetPosition = currentPath.GetPosition(_currentWaypoint);
            }
            else
            {// reached the end of the path, deactivate the enemy
                gameObject.SetActive(false);
            }
        }
    }
}
