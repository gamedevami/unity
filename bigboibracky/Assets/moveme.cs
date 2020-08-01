using UnityEngine;
using System.Collections;

public class moveme : MonoBehaviour {

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float speed = 5f;
    public float xSpeed = 0f;
    private bool isJumping = false;
    private bool isGrounded = false;
    private bool isBtnPressed = false;
    Rigidbody rb;
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
        isBtnPressed = false;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isJumping = true;
            isGrounded = false;
        }
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isDPressed = Input.GetKey(KeyCode.D);
        if(isAPressed ^ isDPressed) {
            xSpeed = isAPressed ? speed : -speed;
        } else {
            xSpeed = 0;
        }
    }

    void FixedUpdate() {
        Vector3 velocity = rb.velocity;
        if(isJumping) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
        if(xSpeed != 0) {
            rb.AddForce(new Vector3(xSpeed, 0, 0) * Time.fixedDeltaTime, ForceMode.VelocityChange);
            velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
            rb.velocity = velocity;
        }
    }
}