using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private float Smoothing = 0.2f;
    [SerializeField]
    private Vector2 MinCameraBoundary;
    [SerializeField]
    private Vector2 MaxCameraBoundary;

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(Player.position.x, Player.position.y, this.transform.position.z);

        //targetPos.x = Mathf.Clamp(targetPos.x, MinCameraBoundary.x, MaxCameraBoundary.x);
        //targetPos.y = Mathf.Clamp(targetPos.y, MinCameraBoundary.y, MaxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, Smoothing);
    }
}
