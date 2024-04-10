using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UserTracking : MonoBehaviour
{
    private InputDevice device;

    void Start()
    {
        // ヘッドセットのデバイスを取得
        device = InputDevices.GetDeviceAtXRNode(XRNode.Head);
    }

    void Update()
    {
        Vector3 headPosition;
        Quaternion headRotation;

        // デバイスの位置と回転を取得
        if (device.TryGetFeatureValue(CommonUsages.devicePosition, out headPosition) &&
            device.TryGetFeatureValue(CommonUsages.deviceRotation, out headRotation))
        {
            transform.position = headPosition;
            transform.rotation = headRotation;
        }
    }
}
