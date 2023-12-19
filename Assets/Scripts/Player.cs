using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    private float speed = 5.0f;

    private Vector3 inputStartPos;
    private Vector3 inputEndPos;
    private bool isDragging = false;

    private float MinXBoundary = -0.6f;
    private float MaxXBoundary = 0.6f;

    private void Update()
    {
        characterController.Move(-(Vector3.forward * speed) * Time.deltaTime);
        HandleInput();
    }

    private void HandleInput()
    {
#if UNITY_EDITOR
        // ������ �Ǵ� ���ĵ��� ���忡���� ���콺 �Է��� ���
        if (Input.GetMouseButtonDown(0))
        {
            inputStartPos = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0))
        {
            inputEndPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
#else
        // ����� ȯ�濡���� ��ġ �Է��� ���
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    inputStartPos = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    inputEndPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
#endif

        if (isDragging)
        {
            Vector3 dragDelta;

#if UNITY_EDITOR
            dragDelta = inputEndPos - inputStartPos;
#else
            // ����� ȯ�濡���� ���� ��ǥ�� ��ȯ �ʿ�
            dragDelta = Camera.main.ScreenToWorldPoint(inputEndPos) - Camera.main.ScreenToWorldPoint(inputStartPos);
#endif

            Vector3 moveDirection = new Vector3(dragDelta.x, 0, 0).normalized;

            float deltaX = moveDirection.x * speed * Time.deltaTime;
            float newXPosition = Mathf.Clamp(transform.position.x + deltaX, MinXBoundary, MaxXBoundary);

            characterController.Move(new Vector3(newXPosition - transform.position.x, 0, 0));

            // ���� �������� ���� ���� ��ġ ������Ʈ
            inputStartPos = inputEndPos;
        }
    }
}
