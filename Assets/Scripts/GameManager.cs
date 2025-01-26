using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // �������� ��� ������� � GameManager

    public int maxLives = 3;     // ������������ ���������� ������
    private int currentLives;    // ������� ���������� ������
    public GameObject vignette;  // ������ �� ������ vignette
    public GameObject hearts;    // ������ �� ������ Hearts
    public List<GameObject> heartSprites; // ������ �������� ������
    public float bottomScreenY = -5f; // ������ ������� ������
    private bool isGameOver = false; // ���� ��� ������������ Game Over
    public float restartDelay = 3f; // ����� �������� ����� ������������ �����

    void Awake()
    {
        // ��������
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = maxLives;
        if (vignette == null)
        {
            Debug.LogWarning("������ �� ������ vignette �� �����������.");
        }
        else
        {
            vignette.SetActive(false); // �������� vignette � ������ ����
        }

        if (hearts == null)
        {
            Debug.LogWarning("������ �� ������ hearts �� �����������.");
        }
        else
        {
            UpdateHeartsDisplay(); // �������������� �����������
        }
    }

    public void TakeDamage()
    {
        if (isGameOver) return; // �� ��������� ����� ���� ���� ��� ���������.

        currentLives--;
        Debug.Log("������ ��������: " + currentLives);

        if (currentLives == 1 && vignette != null)
        {
            vignette.SetActive(true);
        }
        UpdateHeartsDisplay();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    public bool IsOrangeOutsideScreen(Transform orangeTransform)
    {
        return orangeTransform.position.y < bottomScreenY;
    }

    private void UpdateHeartsDisplay()
    {
        if (hearts == null || heartSprites == null)
        {
            return;
        }
        // ��������� ��������� ������ � ������������ � currentLives
        for (int i = 0; i < heartSprites.Count; i++)
        {
            heartSprites[i].SetActive(i < currentLives); // ���������� ������ ������ ���������� ������
        }
    }

    private void GameOver()
    {
        isGameOver = true; // ������ ����
        Time.timeScale = 0; // ������������� �����
        StartCoroutine(RestartGameCoroutine()); // ��������� ���������� ���� ����� Coroutine
    }

    private IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(restartDelay); // ��������

        Time.timeScale = 1; // ������������ �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� �����
    }
}
