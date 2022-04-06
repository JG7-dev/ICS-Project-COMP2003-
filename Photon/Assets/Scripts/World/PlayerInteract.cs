using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float distance = 3f;

    private PlayerUI _playerUI;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<PlayerLook>()._camera;
        _playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerUI.UpdateText(String.Empty);
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo,distance,_mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                _playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
