using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f * 1.5f;
    private Vector3 moveDirection;
    private float runSpeed;
    private bool isRun = false;
    private float t = 1;
    private bool flyMode = false;

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (groundedPlayer || flyMode)
        {
            Vector3 moveX = cam.transform.right * Input.GetAxis("Horizontal");
            Vector3 moveZ = Quaternion.AngleAxis(-90, Vector3.up) * cam.transform.right * Input.GetAxis("Vertical");
            
            moveDirection = moveX + moveZ;

            if (isRun != Input.GetKey("left shift"))
            {
                isRun = Input.GetKey("left shift");
                t = 0;
            }

            runSpeed = Input.GetKey("left shift") ? Mathf.Lerp(2, 4, t) : Mathf.Lerp(4, 2, t);

            if (t < 1)
            {
                t += 32 * Time.deltaTime;
            }
            else
            {
                t = 1;
            }
        }

        controller.Move(moveDirection * Time.deltaTime * playerSpeed * runSpeed);

        // Changes the height position of the player..
        if (Input.GetAxisRaw("Jump") == 1 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
        }

        if (Input.GetKeyDown("space") && !groundedPlayer)
        {
            flyMode = true;
        }

        if (groundedPlayer)
        {
            flyMode = false;
        }

        if (flyMode && Input.GetKey("space"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
