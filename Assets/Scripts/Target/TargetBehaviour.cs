using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetBehaviour : MonoBehaviour
{
    public static int score = 0;
    public int increment = 1;
    public GameObject scoreText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score += increment;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Puntaje: " + score;
        }
    }
}
