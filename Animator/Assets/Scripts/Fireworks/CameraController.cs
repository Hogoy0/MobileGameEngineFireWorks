using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float rotationSpeed = 2f;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
            moveDirection += Vector3.down; 
        if (Input.GetKey(KeyCode.E))
            moveDirection += Vector3.up; 
        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
            transform.eulerAngles += rotation;
        }
    }
}
