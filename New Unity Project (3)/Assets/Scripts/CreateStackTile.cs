using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStackTile : MonoBehaviour {
    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject yourPrefab;
    private int height = 0;


    int GetStackHeight() {
        GameObject highest = gameObject;
        GameObject[] foundStackTiles = GameObject.FindGameObjectsWithTag("StackTile");
        foreach(GameObject curr in foundStackTiles) {
            if(curr.transform.position.y > highest.transform.position.y) {
                highest = curr;
            }
        }
        return (int)highest.transform.position.y / 2;
    }

    void Update() {
        int lastHeight = height;
        Debug.Log(GetStackHeight());
        height = Mathf.Max(GetStackHeight(), height);
        if (lastHeight < height) { GameOver();  }
        if(Input.GetButtonDown("Fire1")) {
            mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                Camera.main.transform.position.y + 2.0f,
                Camera.main.transform.position.z
            );
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(yourPrefab, objectPos, Quaternion.identity);
        }
    }
    void GameOver() { Debug.Log("You lose!");  } //TODO: Implement this
}
