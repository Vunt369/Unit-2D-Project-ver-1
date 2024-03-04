using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_Nhannq : MonoBehaviour
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        float elapsedTime;

        // Update is called once per frame
        void Update()
        {
            elapsedTime += Time.deltaTime;
            int minute = Mathf.FloorToInt(elapsedTime / 60);
            int second = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minute, second);

        }
    }
}
