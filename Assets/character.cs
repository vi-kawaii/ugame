using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public CharacterController controller;
    public Camera camera;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 moveX = camera.transform.right * Input.GetAxis("Horizontal");
        Vector3 moveZ = Quaternion.AngleAxis(-90, Vector3.up) * camera.transform.right * Input.GetAxis("Vertical");
        
        var moveDirection = moveX + moveZ;

        controller.Move(moveDirection * Time.deltaTime * playerSpeed * (Input.GetKey("left shift") ? 4 : 1));

        // Changes the height position of the player..
        if (Input.GetAxisRaw("Jump") == 1 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.5f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
