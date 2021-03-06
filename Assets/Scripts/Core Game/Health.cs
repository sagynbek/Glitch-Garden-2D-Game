﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject particleOnDestoy;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy();
        }
    }

    public float GetHealth() { return health; }

    private void Destroy()
    {
        Destroy(gameObject);

        if (particleOnDestoy)
        {
            var particle = Instantiate(particleOnDestoy, transform.position, Quaternion.identity);
            Destroy(particle, 3);
        }
    }
}
