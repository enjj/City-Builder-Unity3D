﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    public GameObject buildingPrefab;
    public Transform ground;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void CreateBuilding(Vector3 gridPos,GridStructure grid) {
        GameObject newStructure = Instantiate(buildingPrefab, gridPos + ground.position, Quaternion.identity);
        grid.PlaceStructureOnTheGrid(newStructure, gridPos);
    }
}
