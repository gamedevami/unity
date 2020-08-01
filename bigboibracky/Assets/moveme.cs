using UnityEngine;
using System.Collections;

public class moveme : MonoBehaviour {

    private Vector3 jump;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float speed = 0.5f;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 1f, 0f);
    }

    void OnCollisionStay() {
        isGrounded = true;
    }
    void OnCollisionExit() {
        isGrounded = false;
    }

    void Update() {
        bool isAPressed = Input.GetKeyDown(KeyCode.A);
        bool isDPressed = Input.GetKeyDown(KeyCode.D);
        if(isGrounded && (isAPressed ^ isDPressed)) {
            isJumping = true;
            isGrounded = false;
            jump.x = isAPressed ? speed : -speed;
        }
    }

    void FixedUpdate() {
        if(isJumping) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
}