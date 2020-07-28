using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class WreckingBallSpawnManager : MonoBehaviour {
    public float SpawnRadius = 10f;
    public GameObject WreckingBallPrefab;
    // Start is called before the first frame update
    void Start() {

    }

    void FixedUpdate() {
        float randNum = Random.Range(0f, 160f);
        if(randNum < 1f) {
            float randCoord = Random.Range(0f, 2*Mathf.PI);
            Vector3 position = new Vector3();
            position.y = 5f;
            position.x = SpawnRadius * Mathf.Cos(randCoord);
            position.z = SpawnRadius * Mathf.Sin(randCoord);
            Instantiate(WreckingBallPrefab, position, Quaternion.identity);
        }
    }
}
