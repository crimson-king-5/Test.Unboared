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

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            UpdateOnTileGridPlayerPosition();
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = 0; pov_x < fieldOfVisionWidth; pov_x++)
        {
            for (int pov_y = 0; pov_y < fieldOfVisionHeight; pov_y++)
            {
                
            }
        }
    }

    private int UpdateOnTileGridPlayerPosition(int currentValue, bool horizontal)
    {
        if (horizontal)
        {
            
        }
        else
        {
            
        }
        if (onTileGridPlayerPosition.x >= 0)
        {
            onTileGridPlayerPosition.x = playerTilePosition.x % terrainTileHorizontalCount;
        }
        else
        { 
            onTileGridPlayerPosition.x = terrainTileHorizontalCount - 1 
                                         + playerTilePosition.x % terrainTileHorizontalCount;
            
        }

        if (onTileGridPlayerPosition.y > 0)
        {
            onTileGridPlayerPosition.y = playerTilePosition.y % terrainTileVerticalCount;
        }
        else
        {
            onTileGridPlayerPosition.y = terrainTileVerticalCount - 1 
                                         + playerTilePosition.y % terrainTileVerticalCount;
        }
        
       

    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
