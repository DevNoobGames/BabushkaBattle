using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Options")]
    public bool CanMoveLeftRight;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;

    public GameObject CamPivotObj;
    public CameraPivotScript CamPivotScript;

    public Animation MoveAnim;
    public AudioSource JumpAudio;

    [HideInInspector]
    public bool canMove = true;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        if (CanMoveLeftRight)
        {
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        }
        else
        {
            moveDirection = (forward * curSpeedX);
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            JumpAudio.Play();
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }


        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove) //&& Input.GetAxis("Vertical") > 0
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetButtonDown("Vertical"))
        {
            CamPivotScript.CanMove = false;
            transform.localEulerAngles = CamPivotObj.transform.eulerAngles;
            CamPivotObj.transform.localEulerAngles = new Vector3(0, 0, 0);
            MoveAnim.Play();
            MoveAnim["Scene"].speed = 1;
        }
        if (Input.GetButtonUp("Vertical") && !Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            CamPivotScript.CanMove = true;
            MoveAnim["Scene"].speed = 0;
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            CamPivotScript.CanMove = false;
            transform.localEulerAngles = CamPivotObj.transform.eulerAngles;
            CamPivotObj.transform.localEulerAngles = new Vector3(0, 0, 0);
            MoveAnim.Play();
            MoveAnim["Scene"].speed = 1;
        }
        if (Input.GetButtonUp("Horizontal") && !Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            CamPivotScript.CanMove = true;
            MoveAnim["Scene"].speed = 0;
        }
    }
}
