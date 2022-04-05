using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera _camera;

    [SerializeField] private float xRotation = 0f, xSensitivity = 30f, ySensitivity = 5f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        _camera.transform.localRotation = quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up*(mouseX*Time.deltaTime)* xSensitivity);
    }
}
