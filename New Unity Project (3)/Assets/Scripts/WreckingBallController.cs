using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WreckingBallController : MonoBehaviour {
    public float TotalSpeed;
    private Vector3 DirectionalSpeed;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y = 2f;
        transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime);
    }
}
