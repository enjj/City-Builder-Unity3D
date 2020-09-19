﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour {

    public LayerMask mouseInputMask;
    public GameObject buildingPrefab;
    public int cellSize = 3;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }

    public void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin,ray.direction,out hit,Mathf.Infinity,mouseInputMask)) {
                Vector3 position = hit.point - transform.position;
                Debug.Log(CalculateGridPosition(position));
                CreateBuilding(CalculateGridPosition(position));
            }
        }
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition) {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    public void CreateBuilding(Vector3 gridPos) {
        Instantiate(buildingPrefab, gridPos, Quaternion.identity);
    }
}
