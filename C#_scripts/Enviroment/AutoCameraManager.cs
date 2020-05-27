using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCameraManager : MonoBehaviour
{
    // Deklaracia premennych
    public GameObject car;
    private float dist = -4f;
    private float height = 4f;
    private float damp = 0.1f;

    // Konfiguracia kamery, aby postupne isla za vozidlom (hladko) a drzala na nom pohlad
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, car.transform.position + car.transform.TransformDirection(new Vector3(0f, height, dist)), damp * Time.deltaTime);
        transform.LookAt(car.transform);
    }
}
