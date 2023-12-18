using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
