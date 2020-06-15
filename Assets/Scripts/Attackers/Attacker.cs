using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int borderPassStar = 50;
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;
    Animator animator;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController) {
            levelController.AttackerKilled();
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget){return;}

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    public int GetBorderPassStar() { return borderPassStar; }

    public void DestroyAttacker()
    {
        Health health = GetComponent<Health>();
        health.DealDamage(health.GetHealth()); // Destroy object
    }
}
