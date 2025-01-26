using UnityEngine;

public class OrangeController : MonoBehaviour
{
    void Update()
    {
        // ��������� �������� �� �������� ������
        if (GameManager.Instance.IsOrangeOutsideScreen(transform))
        {
            GameManager.Instance.TakeDamage();
            Destroy(gameObject); // ���������� ��������
        }
    }
}
