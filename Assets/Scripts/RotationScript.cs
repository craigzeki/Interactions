//adapted version of gyro code provided by user 'Madgvox' on Unity forum: https://forum.unity.com/threads/gyro-rotation-but-in-local-space.989537/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float _rotationMagnitude = 0.5f;
    Quaternion referenceRotation;

    private void Start()
    {
        Input.simulateMouseWithTouches = true;

        Input.gyro.enabled = true;
        Screen.orientation = ScreenOrientation.Portrait;

        referenceRotation = Quaternion.Inverse(Input.gyro.attitude);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // re-orient to current position on touch to prove that it can always be relative to current screen orientation
            referenceRotation = Quaternion.Inverse(Input.gyro.attitude);
        }

        var raw = Input.gyro.attitude;
        // make the rotation relative to the current rotation rather than the world
        var rot = referenceRotation * raw;

        var euler = rot.eulerAngles;

        var zRot = Quaternion.AngleAxis(euler.z, Vector3.forward);

        // reverse the rotation about the z-axis
        rot = Quaternion.Inverse(zRot) * rot;

        // rotate about the x axis to make the y axis point the right direction
        // CZ: removed this as it rotated the entire object to face downwards
        //rot = Quaternion.AngleAxis(90, Vector3.right) * rot;

        var up = rot * Vector3.up;
        var right = rot * Vector3.right;
        var fwd = rot * Vector3.forward;

        Debug.DrawRay(transform.position, up, Color.green);
        Debug.DrawRay(transform.position, right, Color.red);
        Debug.DrawRay(transform.position, fwd, Color.blue);

        rot = GyroToUnity(rot);
        //rot.eulerAngles *= _rotationMagnitude;
        transform.rotation = rot;
    }

    //CZ: added this to correct for phone to world space
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, -q.z, q.y, -q.w);
    }
}
