using UnityEngine;

public class Balance : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float targetRotation;
    [SerializeField]
    private float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));
    }

}
