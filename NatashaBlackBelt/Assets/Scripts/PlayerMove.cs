using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15f;
    public float  mouseSens = 100f;
    public float yaw;
    public float pitch;
    Rigidbody rb;
    public GameObject viewCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rb.AddForce(transform.forward * vertical * 40);
        rb.AddForce(transform.right * horizontal * 40);
        

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
     
        yaw += mouseX;
        pitch += mouseY * -1;
        viewCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        transform.eulerAngles = new Vector3(0, yaw);
    }
}
