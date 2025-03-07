using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnt : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 35f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    public float jumpCount = 0;
    public float maxjumpcount = 2;

    public bool SlamJump = false;

    public bool timeSlow = true;
    public float TimeScale;

    //private float StartTimeScale;
    //private float StartFixedDeltaTime;

    //private float lastY;
    public float fallingThreshold = -0.01f;

    public float jumpThreshold = 1.5f;
    public float slammerTim;

    [HideInInspector]
    public bool falling = false;

    //cool downs
    [SerializeField]

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Update()
    {
        var currentVelocity = characterController.velocity.y;
        if (characterController.isGrounded) currentVelocity = 0f;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        if (Input.GetButtonDown("Jump") && jumpCount < maxjumpcount)
        {
            moveDirection.y = jumpPower;
            jumpCount++;
        }
        
        else
        {
            moveDirection.y = movementDirectionY;
        }
        
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && !characterController.isGrounded)
        {
            Slams();
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            
        }

        if (Input.GetKey(KeyCode.LeftControl) && !!characterController.isGrounded)
        {
            Slide();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            SlideEnd();
        }

        if (jumpCount == 3)
        {
            Invoke("CheckIfGrounded", 5f);
        }
        if (jumpCount >= 2)
        {
            CheckIfGrounded();
        }
    }

    void Slams()
    {
        jumpCount = 3f;
        gravity = 900;
    }
    void Slide()
    {
        characterController.height = crouchHeight;
        walkSpeed = crouchSpeed;
    }
    void SlideEnd()
    {
        characterController.height = defaultHeight;
        walkSpeed = 20;
    }

    void CheckIfGrounded()
    {
        if (characterController.isGrounded || characterController.isGrounded && SlamJump == false)
        {
            gravity = 7f;
            jumpCount = 0;
        }
    }

   
}
