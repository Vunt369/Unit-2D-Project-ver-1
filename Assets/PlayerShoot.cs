using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int numberOfButllet = 10;
    public TextMeshProUGUI bulletText;

    [SerializeField] GameObject pauseMenu;
    void Start()
    {
        bulletText.SetText(numberOfButllet.ToString());
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!pauseMenu.activeSelf)
            {
                Debug.Log("Bat dau ban");
                if (numberOfButllet > 0)
                {
                    numberOfButllet--;
                    shoot();
                    bulletText.SetText(numberOfButllet.ToString());
                }
                else
                {
                    Debug.Log("HetDan");
                }
            }
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
