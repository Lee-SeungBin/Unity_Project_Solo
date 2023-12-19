using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 startOffset;

    private void Start()
    {
        startOffset = transform.position - player.position;
    }

    private void Update()
    {
        transform.position = player.position + startOffset;
        //Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        //targetPos.x = Mathf.Clamp(targetPos.x, MinCameraBoundary.x, MaxCameraBoundary.x);
        //targetPos.y = Mathf.Clamp(targetPos.y, MinCameraBoundary.y, MaxCameraBoundary.y);

        //transform.position = Vector3.Lerp(transform.position, player.position + startOffset, smoothing);
    }
}
