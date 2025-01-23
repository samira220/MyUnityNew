using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ��� ���������
    public float spawnRate = 1f;     // ������� ���������
    private float nextSpawnTime;       // ����� ���������� ���������
    private GameObject[] spawnPoints; // ������ ����� ������

    void Start()
    {
        // ���� ��� ������� � ����� SpawnPoint
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("�� ������ �� ���� ������ � ����� SpawnPoint!");
            enabled = false; // ��������� ������, ���� ����� ���
        }
    }

    void Update()
    {
        // ���������, ������ �� ����� ��� ���������
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            // ������������� ����� ���������� ���������
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void Spawn()
    {
        if (spawnPoints.Length > 0)
        {
            // �������� ��������� ����� ������
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
