using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotate : MonoBehaviour
{
    public float delay = 71.0f; // 변경을 시작하기 전의 대기 시간
    public float delay2 = 100.0f; 
    public Vector3 targetRotation = new Vector3(45, 0, 0); // 목표 회전 각도
    public Vector3 originalRotation = new Vector3(0, 0, 0);
    private float timer = 0.0f;
    public bool isRotating = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay && timer <= delay2)
        {
            isRotating = true;
            RotateCamera();
        }

        if (timer >= delay2)
        {
            RotateOriginalCamera();

        }
    }

    void RotateCamera()
    {
        // 목표 회전 각도로 부드럽게 회전
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, Time.deltaTime * 30.0f);

        // 목표 각도에 도달하면 회전 종료
        if (transform.rotation == targetQuaternion)
        {
            isRotating = false;
        }
       
    }

    void RotateOriginalCamera()
    {
        // 목표 회전 각도로 부드럽게 회전
        Quaternion targetQuaternion = Quaternion.Euler(originalRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, Time.deltaTime * 30.0f);

        // 목표 각도에 도달하면 회전 종료
        if (transform.rotation == targetQuaternion)
        {
            isRotating = false;
        }

    }
}
