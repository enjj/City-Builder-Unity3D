﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlacementManager placementManager;
    public InputManager inputManager;
    private GridStructure grid;
    private int cellSize = 3;
    public int width, length;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridStructure(cellSize,width,length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position) {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (grid.IsCellTaken(gridPosition) == false) {
            placementManager.CreateBuilding(gridPosition,grid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
