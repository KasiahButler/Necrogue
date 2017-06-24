using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotationSpeed = 5;

    private Vector3 targetPosition;
    private Queue<Vector3> targetPositions = new Queue<Vector3>();
    private bool targetReached = false;

    public void Update()
    {
        CheckTargetReached();
        MoveToTarget();
    }

    public void SetTargetPosition(Vector3 _target)
    {
        targetPositions.Enqueue(_target);
    }

    public void CheckTargetReached()
    {
        if (Vector3.Distance(this.transform.position, targetPosition) <= .25f && targetPositions.Count > 0)
        {
            targetPosition = targetPositions.Dequeue();
        }
        else targetReached = false;
    }

    public void MoveToTarget()
    {
        if(targetReached)
        {
            return;
        }

        Vector3 targetDir = targetPosition - transform.position;
        float RotateStep = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotationSpeed, .5f);

        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position += (targetPosition - transform.position) * Time.deltaTime;
    }
}
