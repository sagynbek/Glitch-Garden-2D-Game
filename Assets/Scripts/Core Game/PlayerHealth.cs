using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text playerHealthText;
    [SerializeField] int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthPoint();
    }

    public void DealDamage(int amount)
    {
        health = Mathf.Max(health-amount, 0);
        UpdateHealthPoint();
        if (health <= 0) {
            GameOver();
        }
    }
    
    void UpdateHealthPoint()
    {
        playerHealthText.text = health.ToString();
    }

    void GameOver()
    {
        FindObjectOfType<LevelLoader>().LoadGameOverScene();
    }
}
