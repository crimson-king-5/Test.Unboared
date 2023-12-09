using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField]private Vector2Int playerTilePosition;
    private Vector2Int onTileGridPlayerPosition;
    [SerializeField] private float tileSize = 20f;
    private GameObject[,] terrainTiles;
    [SerializeField] private int terrainTileHorizontalCount;
    [SerializeField] private int terrainTileVerticalCount;
    [SerializeField] private int fieldOfVisionHeight = 4;
    [SerializeField] private int fieldOfVisionWidth = 4;
    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0; 
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0; 

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);

            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = - (fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth/2; pov_x++)
        {
            for (int pov_y = - (fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++)
            {
                int tileUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                Debug.Log("tileToUpdate_x" + tileUpdate_x + "tileToUpdate_y" + tileUpdate_y);

                GameObject tile = terrainTiles[tileUpdate_x, tileUpdate_y];
                tile.transform.position = CalculatTilesPosition(
                     playerTilePosition.x + pov_x,
                     playerTilePosition.y + pov_y
                     );
            }
        }
    }

    private Vector3 CalculatTilesPosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {

                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
      
  

    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
