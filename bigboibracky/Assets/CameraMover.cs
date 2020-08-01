using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float freezedYCoordinate;
    // Update is called once per frame
    void Update() {
        Vector3 pos = playerPos.position;
        pos.y = freezedYCoordinate;
        transform.position = pos + cameraOffset;
    }
}
