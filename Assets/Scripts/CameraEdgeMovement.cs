using UnityEngine;

public class CameraEdgeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения камеры
    public float edgeThreshold = 0.1f; // Порог (10% от ширины экрана)
    public float minX = -10f; // Минимальная позиция по X
    public float maxX = 10f; // Максимальная позиция по X

    void Update()
    {
        // Получаем позицию мыши в координатах экрана (0-1)
        Vector2 mousePosition = Input.mousePosition;
        float normalizedMouseX = mousePosition.x / Screen.width;

        // Определяем, находится ли мышь у края экрана
        bool mouseAtLeftEdge = normalizedMouseX < edgeThreshold;
        bool mouseAtRightEdge = normalizedMouseX > (1f - edgeThreshold);

        // Вычисляем направление движения
        float moveDirection = 0f;
        if (mouseAtLeftEdge) moveDirection = -1f;
        else if (mouseAtRightEdge) moveDirection = 1f;

        // Если мышь у края - двигаем камеру
        if (moveDirection != 0f)
        {
            Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }
    }
}
