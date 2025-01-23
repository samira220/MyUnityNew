using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject Pause; // ������ �� UI Image
    private bool isPaused = false;  // ���� ��� ������������ ��������� �����

    void Start()
    {
        // ���������, ��������� �� ��������
        if (Pause == null)
        {
            Debug.LogError("�� ��������� UI-�������� � PauseManager!");
            enabled = false; // ��������� ������, ���� �������� �� ���������
        }
        else
        {
            Pause.SetActive(false); // ������ �������� ���������� � ������
        }
    }

    void Update()
    {
        // ��������� ������� ������� Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToglePause(); // ����������� ��������� �����
        }
    }

    private void ToglePause()
    {
        isPaused = !isPaused; // ����������� ��������� �����
        Pause.SetActive(isPaused); // ���������� ��� ������������ ��������
        Time.timeScale = isPaused ? 0f : 1f; // ������������ ��� ������������ �����
    }
}


