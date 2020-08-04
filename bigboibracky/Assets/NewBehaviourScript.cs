using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject
                .GetComponent<Rigidbody>()
                .AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }
    }
}

