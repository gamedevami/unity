using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreateStackTile : MonoBehaviour {
    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject yourPrefab;
    private int height = 0;


    public static GameObject FindHighestTile() {
        GameObject[] foundStackTiles = GameObject.FindGameObjectsWithTag("StackTile");
        GameObject highest;
        try {
            highest = foundStackTiles[0];
        } catch(System.Exception) {
            highest = Instantiate(new GameObject(), new Vector3(0f, -5f, 0f), Quaternion.identity);
        }
        foreach(GameObject curr in foundStackTiles) {
            if(curr.transform.TransformPoint(curr.transform.position).y
                > highest.transform.TransformPoint(highest.transform.position).y) {
                highest = curr;
            }
        }
        return highest;
    }

    public static GameObject FindLowestTile() {
        GameObject[] foundStackTiles = GameObject.FindGameObjectsWithTag("StackTile");
        GameObject lowest;
        try {
            lowest = foundStackTiles[0];
        } catch(System.Exception) {
            lowest = Instantiate(new GameObject(), new Vector3(0f, 10000f, 0f), Quaternion.identity);
        }
        foreach(GameObject curr in foundStackTiles) {
            if(curr.transform.TransformPoint(curr.transform.position).y
                < lowest.transform.TransformPoint(lowest.transform.position).y) {
                lowest = curr;
            }
        }
        return lowest;
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            mousePos = Input.mousePosition;
            mousePos.z = 2.0f;

            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(yourPrefab, objectPos, Quaternion.identity);
        }
        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, new Vector3(
                Camera.main.transform.position.x,
                Mathf.Max(FindHighestTile().transform.position.y + 10.0f, 15f),
                Camera.main.transform.position.z
            ), Time.deltaTime);
    }
    void GameOver() { Debug.Log("You lose!"); } //TODO: Implement this
}
