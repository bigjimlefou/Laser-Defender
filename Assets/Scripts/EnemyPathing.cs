using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed;
    private int currentWaypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (currentWaypointIndex >= 0 && waypoints.Count > currentWaypointIndex)
            transform.position = waypoints[currentWaypointIndex].transform.position;
        currentWaypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[currentWaypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
