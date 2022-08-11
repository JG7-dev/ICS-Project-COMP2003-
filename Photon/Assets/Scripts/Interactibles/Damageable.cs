using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    float currentHp;

    [SerializeField] GameObject hitEffect;

    void Awake()
    {
        currentHp = maxHealth;
    }

    public void Takedamage(float damage, Vector3 hitpos, Vector3 hitnormal)
    {
        Instantiate(hitEffect, hitpos, Quaternion.LookRotation(hitnormal));
        currentHp -= damage;
        if (currentHp <=0)
        {
            Die();
        }
    }
    void Die()
    {
        print(name + "was killed");
        Destroy(gameObject);
    }
}
