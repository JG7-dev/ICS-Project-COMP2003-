using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   
    Transform cam;
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 50f;
    private new AudioSource audio;
    

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Awake()
    {
        cam = Camera.current.transform;
    }
    private void Update()
    {
       
    }

    public void Shoot()
    {
        

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            audio.PlayOneShot(audio.clip);
            Debug.Log(hit.transform.name);
            Damageable damageable =hit.transform.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Takedamage(damage,hit.point,hit.normal);
            }
        } 
    }

}
