using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateStarText();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStarText();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateStarText();
        }
    }

    private void UpdateStarText()
    {
        starText.text = stars.ToString();
    }
    
}
