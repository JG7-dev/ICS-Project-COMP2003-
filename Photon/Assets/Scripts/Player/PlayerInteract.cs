using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 50f;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Shooting _gun;
    public ParticleSystem muzzle;
    private PauseMenu pause;
    public new AudioSource audio;
    public PlayerInput.OnFootActions _onFootActions;
    private Shooting _shooting;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<PlayerLook>()._camera;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
        _onFootActions.Shoot.performed += _ => _shooting.Shoot();
        audio = GetComponent<AudioSource>();
        pause = GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerUI.UpdateText(String.Empty);
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hit;
        
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        
        if (Physics.Raycast(ray, out hit,_distance,_mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(interactable.promptMessage);
                
                if (_inputManager._onFootActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shooting();
        }

    }
    void Shooting()
    {
        muzzle.Play();
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            
            Debug.Log(hit.transform.name);
            Damageable damageable = hit.transform.GetComponent<Damageable>();
            audio.PlayOneShot(audio.clip);
            if (damageable != null)
            {
                damageable.Takedamage(damage, hit.point, hit.normal);
            }
        }
        
    }
}
