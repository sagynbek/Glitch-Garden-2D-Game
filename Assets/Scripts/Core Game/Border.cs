using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            FindObjectOfType<PlayerHealth>().DealDamage(attacker.GetBorderPassStar());
            attacker.DestroyAttacker();
        }

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            projectile.DestroyProjectile();
        }
    }
}
