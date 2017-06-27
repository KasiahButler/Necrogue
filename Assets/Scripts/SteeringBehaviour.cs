using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotationSpeed = 5;
    public float rotationMagnitude = 1;

    public bool isAutomated = false;
    public Transform followTransform;

    private Vector3 targetPosition;
    private Queue<Vector3> targetPositions = new Queue<Vector3>();
    private bool targetReached = false;

    public void Update()
    {
        if(isAutomated)
        {
            AutoFollow();
        }

        CheckTargetReached();
        MoveToTarget();
    }

    public void SetTargetPosition(Vector3 _target)
    {
        targetPositions.Enqueue(_target);
    }

    public void AutoFollow()
    {
        targetPosition = followTransform.position;
    }

    public void CheckTargetReached()
    {
        if (Vector3.Distance(this.transform.position, targetPosition) <= .5f)
        {
            if(targetPositions.Count <= 0)
            {
                targetReached = true;
                return;
            }
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

        Vector3 targetDir = new Vector3(targetPosition.x, 0, targetPosition.z) - new Vector3(transform.position.x, 0, transform.position.z);
        float rotateStep = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateStep, rotationMagnitude);

        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position += targetDir.normalized * moveSpeed * Time.deltaTime;
    }
}
