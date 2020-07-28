using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WreckingBallController : MonoBehaviour {
    public float TotalSpeed;
    private Vector3 DirectionalSpeed;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 point = CreateStackTile.FindLowestTile().transform.position;
        point.y = 5f;
        transform.position = Vector3.Lerp(transform.position, point, Time.deltaTime);
        // Destroy ball if right-clicked on
        if(Input.GetButtonDown("Fire2")) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)) {
                if(hit.transform.gameObject.tag == "WreckingBall") {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
