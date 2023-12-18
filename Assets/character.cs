using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

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
    private float t2 = 1;
    private bool flyMode = false;
    private float cachedVelocity_y = 0;

    void Start()
    {
        StartCoroutine(GetVersion());
    }

    IEnumerator GetVersion()
    {
        UnityWebRequest u = UnityWebRequest.Get("https://vi-kawaii.github.io/ugame/version.txt");
        yield return u.SendWebRequest();

        if (u.isNetworkError || u.isHttpError)
        {
            Debug.Log(u.error);
        }
        else
        {
            string remoteVersion = u.downloadHandler.text;
            string version = File.ReadAllText("version.txt");
            if (version != remoteVersion)
            {
                File.WriteAllText("version.txt", remoteVersion);
                // download and unpack zip in folder with version name
            }
        }
    }

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
                t += 8 * Time.deltaTime;
            }
            else
            {
                t = 1;
            }
        }

        if (flyMode && Input.GetKey("left shift"))
        {
            runSpeed *= 1.5f;
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
            if (t2 < 1)
            {
                t2 += 3 * Time.deltaTime;
            }
            else
            {
                t2 = 1;
            }

            if (cachedVelocity_y == 0)
            {
                cachedVelocity_y = playerVelocity.y;
            }

            playerVelocity.y = Mathf.Lerp(cachedVelocity_y, Mathf.Sqrt(jumpHeight * -1.0f * gravityValue), t2);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        if (flyMode && !Input.GetKey("space"))
        {
            t2 = 0;
            cachedVelocity_y = 0;
        }

        if (flyMode && Input.GetKey("left shift"))
        {
            playerVelocity.y = 0;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.transform.GetChild(0).transform.GetComponent<npc_ui>().TakeDamage();
                }
            }
        }
    }
}
