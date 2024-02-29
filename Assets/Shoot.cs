using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.XR;


public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();    
        }
    }
    void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
