using UnityEngine;
using System.Collections;

public class moveme : MonoBehaviour {

    private Vector3 jump;
    [SerializeField] private float jumpForce = 0.4f;
    [SerializeField] private float speed = 0.2f;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody rb;
    private Animator anim;
    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jump = new Vector3(-0.4f, 0.2f, 0f);
    }

    void OnTriggerStay() {
        isGrounded = true;
        anim.ResetTrigger("Jump");
    }
    void OnTriggerExit() {
        isGrounded = false;
        anim.SetTrigger("Jump");
    }

    void Update() {
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isDPressed = Input.GetKey(KeyCode.D);
        if(isGrounded && (isAPressed ^ isDPressed)) {
            isJumping = true;
            isGrounded = false;
            jump.x = isAPressed ? speed : -speed;
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    void FixedUpdate() {
        if(isJumping) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
}