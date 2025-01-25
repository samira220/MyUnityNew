using UnityEngine;

public class ChebuFlip : MonoBehaviour
{
    public float flipLineX = 0f; // ���������� X ����� ��� ��������
    private bool isFacingRight = true; // ����, ������������ ������� �����������

    void Update()
    {
        // �������� ������� ������� �������
        float chebuX = transform.position.x;

        // ���������, ������� �� ������ �����
        if (isFacingRight && chebuX > flipLineX)
        {
            Flip();
        }
        else if (!isFacingRight && chebuX < flipLineX)
        {
            Flip();
        }
    }

    // ������� ��� �������� �������
    private void Flip()
    {
        isFacingRight = !isFacingRight; // ������ �����������
        Vector3 scale = transform.localScale;
        scale.x *= -1; // ����������� ������� �� ��� X
        transform.localScale = scale;
    }
}
