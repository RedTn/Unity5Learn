using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speedMultiplier = 5.0f;
    public float mouseSensitivity = 5.0f;
    public float jumpSpeed = 5.0f;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;
    CharacterController cc;
    bool onSlope = false;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Rotation

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if(cc.isGrounded && Input.GetButtonDown("Jump") && !onSlope)
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed;
        if (Input.GetButton("Sprint"))
        {
            speed = new Vector3(sideSpeed * 2.0f, verticalVelocity, forwardSpeed * 2.0f) * speedMultiplier;
        }
        else
        {
            speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed) * speedMultiplier;
        }

        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.normal.y <= 0.6)
        {
            onSlope = true;
        }
        else
        {
            onSlope = false;
        }
    }
}
