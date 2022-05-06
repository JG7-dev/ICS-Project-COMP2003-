using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private GameObject _negotiator;
    public int zoom = 1;
    public int normal = 60;
    public float smooth = 20;

    private bool isZoomed = false;

    private void Start()
    {
        _camera = GetComponent<PlayerLook>()._camera;
        _negotiator = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {
            GetComponent<PlayerLook>()._camera.fieldOfView = Mathf.Lerp(GetComponent<PlayerLook>()._camera.fieldOfView, zoom, Time.deltaTime * smooth);
        }
        if (!isZoomed)
        {
            GetComponent<PlayerLook>()._camera.fieldOfView = Mathf.Lerp(GetComponent<PlayerLook>()._camera.fieldOfView, normal, Time.deltaTime * smooth);
        }
     
    }
}
