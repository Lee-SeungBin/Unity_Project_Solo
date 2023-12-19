using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 startOffset;

    private void Start()
    {
        startOffset = new Vector3(0, 0, transform.position.z - player.position.z);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + startOffset.z);
        //Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        //targetPos.x = Mathf.Clamp(targetPos.x, MinCameraBoundary.x, MaxCameraBoundary.x);
        //targetPos.y = Mathf.Clamp(targetPos.y, MinCameraBoundary.y, MaxCameraBoundary.y);

        //transform.position = Vector3.Lerp(transform.position, player.position + startOffset, smoothing);
    }
}
