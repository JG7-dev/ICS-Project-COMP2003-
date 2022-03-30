using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegotiatiorHP
{
    private int maxHP = 100;
    private int currentHP = 100;
    private bool hit = false;
    public Slider HealthBar;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if(hit == true)
        {
            damageTaken();
        }
    }

    void damageTaken()
    {
        //HealthBar.value = ;
    }
}
