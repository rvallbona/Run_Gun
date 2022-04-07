using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform scope;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValue;

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 playerPoss = scope.position + offset;

        Vector3 borderPosition = new Vector3(
            Mathf.Clamp(playerPoss.x, minValues.x, maxValue.x),
            Mathf.Clamp(playerPoss.y, minValues.y, maxValue.y),
            Mathf.Clamp(playerPoss.z, minValues.z, maxValue.z)
            );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, borderPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
