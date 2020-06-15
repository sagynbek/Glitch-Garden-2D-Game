using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Health health = otherCollider.GetComponent<Health>();
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if ( attacker && health)
        {
            health.DealDamage(damage);
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
