using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar_Chau : MonoBehaviour
{

    [SerializeField] private Health_Chau01 playerHeath;
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
