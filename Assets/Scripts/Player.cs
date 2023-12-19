using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private CharacterController characterController;

    private float speed = 5.0f;
    void Start()
    {

    }

    void Update()
    {
        characterController.Move(-(Vector3.forward * speed) * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        transform.position = eventData.position;
    }
}
