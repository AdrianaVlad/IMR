using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public int score;
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = $"Score\n{score}";
    }
    public void AddPoints(int points)
    {
        score += points;
        GetComponent<TextMeshProUGUI>().text = $"Score\n{score}";
    }
}
