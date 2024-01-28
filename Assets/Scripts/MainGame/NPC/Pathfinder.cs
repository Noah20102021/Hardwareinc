using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Transform target;
    public LayerMask obstacleLayer;
    public float speed = 5f;
    public float avoidanceDistance = 2f;

    private void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;

        if (!IsObstacleInWay(direction))
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            // Wenn ein Hindernis im Weg ist, eine neue Richtung um das Hindernis herum finden
            Vector3 avoidanceDirection = FindAvoidanceDirection(direction);
            transform.Translate(avoidanceDirection.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    bool IsObstacleInWay(Vector3 direction)
    {
        // Raycast verwenden, um Hindernisse zu erkennen
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, avoidanceDistance, obstacleLayer))
        {
            return true;  // Hindernis gefunden
        }

        return false;  // Kein Hindernis im Weg
    }

    Vector3 FindAvoidanceDirection(Vector3 direction)
    {
        // Eine Richtung um das Hindernis herum finden
        Vector3 rightAvoidance = Vector3.Cross(Vector3.up, direction.normalized);
        Vector3 leftAvoidance = -rightAvoidance;

        // Priorisiere die Richtung mit weniger Hindernissen
        if (!IsObstacleInWay(rightAvoidance))
        {
            return rightAvoidance;
        }
        else if (!IsObstacleInWay(leftAvoidance))
        {
            return leftAvoidance;
        }

        // Wenn beide Richtungen blockiert sind, gehe einfach zurück
        return -direction.normalized;
    }
}
