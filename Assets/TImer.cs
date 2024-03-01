using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;
    float elapsedTime;
    // Start is called before the first frame update
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
    
