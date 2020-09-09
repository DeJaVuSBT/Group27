using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public float verticalSpeed = 1f;
    public float horizontalSpeed = 2f;
    public float jumpForce = 10f;
    public float turnSpeed = 38f;
    public float adjustTurnSpeed = 2.2f;
    private float Yclamp = 0f;
    public static int score = 0;
    private Rigidbody rb;
    private bool isGrounded = true;
    private Quaternion defaulYtOrientation, targetOrientation;
    public float maxTurn = 9f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        Turn();
    }

    void Move()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed, 0, verticalSpeed);
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        transform.Translate(moveVector * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jumpVector, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Turn()
    {
        Vector3 angle = Vector3.up * Input.GetAxis("Horizontal") * turnSpeed;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(angle * Time.fixedDeltaTime, Space.Self);
                Yclamp = transform.rotation.eulerAngles.y;
                Yclamp = Clamp(Yclamp, -maxTurn, maxTurn);
                targetOrientation = Quaternion.Euler(transform.rotation.eulerAngles.x, Yclamp, transform.rotation.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetOrientation, adjustTurnSpeed * Time.fixedDeltaTime);
            }
            else //comes back to original orientation
            {
                defaulYtOrientation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, defaulYtOrientation, adjustTurnSpeed * Time.fixedDeltaTime);
            }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ocean")
        {
            isGrounded = true;
        }
     
       
    }

    float Clamp(float angle, float min, float max)
    {
        if (angle > 180f) // remap 0 - 360 --> -180 - 180
            angle -= 360f;
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0f) // map back to 0 - 360
            angle += 360f;
        return angle;
    }
}
