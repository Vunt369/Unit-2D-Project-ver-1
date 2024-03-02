using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int numberOfButllet = 10;
    public TextMeshProUGUI bulletText;
    [SerializeField] GameObject pauseMenu;
    //private bool isButtonPressed = false;
    /*void ButtonPressed()
    {
        isButtonPressed = true;
    }*/
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
        /*RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position, shootingPoint.right);
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
            }
            Instantiate(bulletPrefab, hitInfo.point, Quaternion.identity);
        }*/
    }
}
