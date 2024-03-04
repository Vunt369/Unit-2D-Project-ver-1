using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heathbar : MonoBehaviour
{
    [SerializeField] private Heath playerHeath;
    [SerializeField] private Image totalHeathBar;
    [SerializeField] private Image currentheathBar;

    private void Start()
    {
        totalHeathBar.fillAmount = playerHeath.currentHeath / 10;
    }
    private void Update()
    {
        currentheathBar.fillAmount = playerHeath.currentHeath / 10;
    }
}
