using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    bool[,] usedCells = new bool[15, 15];

    public void SetDefender(Defender newDefender)
    {
        defender = newDefender;
    }

    private void OnMouseDown()
    {
        if (defender) {
            AttemptToPlaceDefenderAt(GetSquarePosition());
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if ( usedCells[Mathf.RoundToInt(gridPos.x), Mathf.RoundToInt(gridPos.y)] != true && starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquarePosition()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPosition)
    {
        Defender newDefender = Instantiate(defender, spawnPosition, Quaternion.identity) as Defender;
        usedCells[ Mathf.RoundToInt(spawnPosition.x), Mathf.RoundToInt(spawnPosition.y)] = true;
    }
}
