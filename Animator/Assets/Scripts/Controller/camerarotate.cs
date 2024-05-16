using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotate : MonoBehaviour
{
    public float delay = 71.0f; // ������ �����ϱ� ���� ��� �ð�
    public float delay2 = 100.0f; 
    public Vector3 targetRotation = new Vector3(45, 0, 0); // ��ǥ ȸ�� ����
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
        // ��ǥ ȸ�� ������ �ε巴�� ȸ��
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, Time.deltaTime * 30.0f);

        // ��ǥ ������ �����ϸ� ȸ�� ����
        if (transform.rotation == targetQuaternion)
        {
            isRotating = false;
        }
       
    }

    void RotateOriginalCamera()
    {
        // ��ǥ ȸ�� ������ �ε巴�� ȸ��
        Quaternion targetQuaternion = Quaternion.Euler(originalRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, Time.deltaTime * 30.0f);

        // ��ǥ ������ �����ϸ� ȸ�� ����
        if (transform.rotation == targetQuaternion)
        {
            isRotating = false;
        }

    }
}
