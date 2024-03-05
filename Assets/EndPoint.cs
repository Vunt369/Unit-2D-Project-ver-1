using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject endPointPanel;
    public GameObject turnOffCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("da cham player");
            if(endPointPanel != null)
            {
                endPointPanel.SetActive(true);
                turnOffCanvas.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
}
