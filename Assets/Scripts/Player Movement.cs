using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject LeftLeg;
    [SerializeField]
    private GameObject RightLeg;

    [SerializeField]
    private Rigidbody2D LeftLegRB;
    [SerializeField]
    private Rigidbody2D RightLegRB;
    [SerializeField]
    private Rigidbody2D PlayerRB;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float Speed = 1.5f;
    [SerializeField]
    private float StepWait = 1f;
    [SerializeField]
    private float JumpForce = 10f;
    [SerializeField]
    private float PositionRadius;

    private bool IsGround;

    [SerializeField]
    private LayerMask Ground;
    [SerializeField]
    private Transform PlayerPos;

    void Start()
    {
        animator.Play("RunRight");

        StartCoroutine(Move(StepWait));
    }

    void Update()
    {
        IsGround = Physics2D.OverlapCircle(PlayerPos.position, PositionRadius, Ground);
        if (IsGround && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRB.AddForce(Vector2.up * JumpForce);
        }

    }

    private IEnumerator Move(float seconds)
    {
        while (true)
        {
            LeftLegRB.AddForce(Vector2.right * (Speed * 1000) * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            RightLegRB.AddForce(Vector2.right * (Speed * 1000) * Time.deltaTime);
        }
    }
}
