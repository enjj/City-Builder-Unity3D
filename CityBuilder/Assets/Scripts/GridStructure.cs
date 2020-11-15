﻿using System;
using UnityEngine;

public class GridStructure
{

    private int cellSize = 3;
    private Cell[,] grid;
    private int width, length;

    public GridStructure(int cellSize, int width, int length) {
        this.cellSize = cellSize;
        this.width = width;
        this.length = length;
        grid = new Cell[width, length];

        for (int row = 0; row < grid.GetLength(0); row++) {
            for (int col = 0; col < grid.GetLength(1); col++) {
                grid[row, col] = new Cell();
            }
        }
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition) {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    public Vector2Int CalculateGridIndex(Vector3 gridPosition) {
        return new Vector2Int((int)(gridPosition.x / cellSize), (int)(gridPosition.z / cellSize));
    }

    public bool IsCellTaken(Vector3 gridPosition) {

        Vector2Int cellIndex = CalculateGridIndex(gridPosition);

        if (CheckIndexValidity(cellIndex)) {
            return grid[cellIndex.y, cellIndex.x].IsTaken;
        }
        else {
            throw new IndexOutOfRangeException("No Index" + cellIndex + " in grid");
        }
    }

    public void PlaceStructureOnTheGrid(GameObject structure, Vector3 gridPosition) {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);

        if (CheckIndexValidity(cellIndex)) {
             grid[cellIndex.y, cellIndex.x].SetConstruction(structure);
        }
    }

    private bool CheckIndexValidity(Vector2Int cellIndex) {
        if (cellIndex.x >= 0 && cellIndex.x < grid.GetLength(1) && cellIndex.y >= 0 && cellIndex.y < grid.GetLength(0)) {
            return true;
        }
        else {
            return false;
        }
    }
}
