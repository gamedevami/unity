using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables

    Animator animator;
    float move = 0.0f;
    float movementDelay = 0;
    private bool forward, backward, left, right;
    [SerializeField] private float speed = 0.09f;
    private float rotationSpeed = 2f;

    Vector3 rotation;


    //Functions

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        forward = backward = left = right = false;
        
    }

    void movement(){

        //Rotating along the Y-axis
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime, 0);

        //Setting the Speed parameter to the value of move
        animator.SetFloat("Speed", move);

        if(forward||backward){
            move = 2;            //move = 2 means Player is running
        }
        else{
            move = 0;           //move = 0 means Player is idle
            movementDelay = 0;
        }

        //Rotate the player
        if(left){
            transform.Rotate(this.rotation, rotationSpeed);
        }
        else if(right){
            transform.Rotate(this.rotation, rotationSpeed);
        }

        //Move the player forwards and backwards (not sideways). Left and right are for rotation
        if(move==2){
            if(movementDelay==70){
                if(forward){
                    if(this.rotation.y==0){
                        transform.Translate(0, 0, speed);
                    }
                    else if(this.rotation.y<0){
                        transform.Translate(0, 0, speed - rotation.y * rotationSpeed * Time.deltaTime);
                    }
                    else{
                        transform.Translate(0, 0, speed + rotation.y * rotationSpeed * Time.deltaTime);
                    }
                }
                else if(backward){
                    if(this.rotation.y==0){
                        transform.Translate(0, 0, -speed);
                    }
                    else if(this.rotation.y<0){
                        transform.Translate(0, 0, -speed + rotation.y * rotationSpeed * Time.deltaTime);
                    }
                    else{
                        transform.Translate(0, 0, -speed - rotation.y * rotationSpeed * Time.deltaTime);
                    }
                }
                
            }
            else{
                //Inceremnt movementDelay so that animation starts after a certain time
                ++movementDelay;
            }
        }

        //Trigger movements
        if(Input.GetKeyDown(KeyCode.D)){
            left = false;
            right = true;
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            right = false;
            left = true;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            backward = true;
            forward = false;
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            forward = true;
            backward = false;
        }

        //Reset triggered movements
        if(Input.GetKeyUp(KeyCode.A)){
            left = false;
        }
        if(Input.GetKeyUp(KeyCode.D)){
            right = false;
        }
        if(Input.GetKeyUp(KeyCode.W)){
            forward = false;
        }
        if(Input.GetKeyUp(KeyCode.S)){
            backward = false;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
