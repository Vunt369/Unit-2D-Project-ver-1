using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int numberOfButllet = 10;
    public TextMeshProUGUI bulletText;

    void Start()
    {
        bulletText.SetText(numberOfButllet.ToString());
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            numberOfButllet--;
            shoot();
            bulletText.SetText(numberOfButllet.ToString());

        }
    }
    void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);

    }
}
