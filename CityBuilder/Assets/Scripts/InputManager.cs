using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour {

    public LayerMask mouseInputMask;
    //public GameObject buildingPrefab;

    void Update() {
        GetInput();
    }

    public void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin,ray.direction,out hit,Mathf.Infinity,mouseInputMask)) {
                Vector3 position = hit.point - transform.position;
                Debug.Log(position);
            }
        }
    }

   
//    public void CreateBuilding(Vector3 gridPos) {
//        Instantiate(buildingPrefab, gridPos, Quaternion.identity);
//    }
}
