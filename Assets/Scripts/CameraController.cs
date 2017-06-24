using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 velocity = Vector3.zero;

    public float followStep;
    public float followDistance;
    public float followHeight;

    private bool isActive = true;

    public void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (!isActive)
        {
            return;
        }
        Vector3 targetPoint = targetTransform.position + new Vector3(0, followHeight, followDistance);

        this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPoint, ref velocity, followStep);
    }
}
