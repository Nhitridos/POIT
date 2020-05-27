using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Deklaracia premennych
    public GameObject car;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Konfiguracia kamery, aby neustale drzala od auta rovnako vzdialenost a pohlad na auto
    void FixedUpdate()
    {
        transform.LookAt(car.transform);
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 1.7f, -5f));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
