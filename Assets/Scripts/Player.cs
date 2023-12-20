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
        // 에디터 또는 스탠드얼론 빌드에서는 마우스 입력을 사용
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
        // 모바일 환경에서는 터치 입력을 사용
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    inputStartPos = touch.position;
                    isDragging = false;
                    break;

                case TouchPhase.Moved:
                    isDragging = true;
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
            Vector2 dragDelta;
            dragDelta = inputEndPos - inputStartPos;


            Vector3 moveDirection = new Vector3(dragDelta.x, 0, 0).normalized;

            float deltaX = moveDirection.x * speed * Time.deltaTime;
            float newXPosition = Mathf.Clamp(transform.position.x + deltaX, MinXBoundary, MaxXBoundary);

            characterController.Move(new Vector3(newXPosition - transform.position.x, 0, 0));

            // 다음 프레임을 위해 시작 위치 업데이트
            inputStartPos = inputEndPos;
        }
    }
}
