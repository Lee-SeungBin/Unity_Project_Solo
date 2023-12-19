using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float score = 0.0f;

    [SerializeField]
    private Text scoreText;

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }
}
