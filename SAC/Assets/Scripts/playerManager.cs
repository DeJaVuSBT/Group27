using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private gameMaster gm;
    private SoundScript sound;
    public WaterFloat wf;
    public float verticalSpeed = 1f;
    public float horizontalSpeed = 2f;
    public float jumpForce = 10f;
    public float turnSpeed = 38f;
    public float adjustTurnSpeed = 2.2f;
    private float Yclamp = 0f;
    public int score = 0;
    private Rigidbody rb;
    private bool ablejump = false;
    
    private Quaternion defaulYtOrientation, targetOrientation;
    public float maxTurn = 9f;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        sound = GameObject.FindObjectOfType<SoundScript>();
        score = gm.lastScore;
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

        if(Input.GetKeyDown(KeyCode.Space) && wf.AbleJump == true|| Input.GetKeyDown(KeyCode.Space) && ablejump)
        {
            sound.Play("jumpup");
            rb.AddForce(jumpVector, ForceMode.Impulse);
            ablejump = false;
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

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Trash")
        {
            sound.Play("collect");
            Destroy(collision.gameObject);
            score++;
        }
        if (collision.tag == "Ocean")
        {
            ablejump = true;
            Debug.Log("hihihihi");
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
