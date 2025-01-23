using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{
    public float moveSpeed; // �������� ��������

    private Rigidbody2D rb; // ������ �� Rigidbody2D
    void Start()
    {
        // �������� ������ �� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D �� ������ �� �������!");
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        // �������� ���� � ����������
        float horizontalInput = 0f;
        float verticalInput = 0f;
        bool _isPause = false;
        if (Input.GetKey(KeyCode.Q))
        {
            horizontalInput = -1f;
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
            verticalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
            verticalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            horizontalInput = 1f;
            verticalInput = 1f;
        }

        // ������� ������ ��������
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // ������� ������
        if (rb != null)
            rb.velocity = moveDirection * moveSpeed;

        
    }

}
