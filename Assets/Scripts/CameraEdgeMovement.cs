using UnityEngine;

public class CameraEdgeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ������
    public float edgeThreshold = 0.1f; // ����� (10% �� ������ ������)
    public float minX = -10f; // ����������� ������� �� X
    public float maxX = 10f; // ������������ ������� �� X

    void Update()
    {
        // �������� ������� ���� � ����������� ������ (0-1)
        Vector2 mousePosition = Input.mousePosition;
        float normalizedMouseX = mousePosition.x / Screen.width;

        // ����������, ��������� �� ���� � ���� ������
        bool mouseAtLeftEdge = normalizedMouseX < edgeThreshold;
        bool mouseAtRightEdge = normalizedMouseX > (1f - edgeThreshold);

        // ��������� ����������� ��������
        float moveDirection = 0f;
        if (mouseAtLeftEdge) moveDirection = -1f;
        else if (mouseAtRightEdge) moveDirection = 1f;

        // ���� ���� � ���� - ������� ������
        if (moveDirection != 0f)
        {
            Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }
    }
}
