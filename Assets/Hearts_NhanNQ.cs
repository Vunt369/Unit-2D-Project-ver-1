using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public static int hearts;
    public float seconds = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
<<<<<<< HEAD
    private CapsuleCollider2D capsuleCollider;
    void Start()
    {
        heartsText.SetText(hearts.ToString());
        capsuleCollider = GetComponent<CapsuleCollider2D>();
=======
    public GameObject heart1, heart2, heart3, gameOverObject;

    void Start()
    {
        hearts = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOverObject.gameObject.SetActive(false);
>>>>>>> vunt
    }

    void Update()
    {
        if (seconds >= 3f)
        {
            seconds = 3f;
        }
        else
        {
            seconds += Time.deltaTime;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            if (seconds >= 3f)
            {
                seconds = 3f;
				color.a =1f;
                spriteRenderer.color = color;
            }
        }
        if(hearts == 0)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
<<<<<<< HEAD
        if (seconds == 3f)
        {
            animator.SetBool("IsHurt", false);
        }

        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")) && seconds == 3f)
=======


        switch (hearts)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOverObject.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            default:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOverObject.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemies") && seconds == 3f)
>>>>>>> vunt
        {
            hearts = hearts - 1;
            seconds = 0;
            animator.SetBool("IsHurt", true);
        }
<<<<<<< HEAD
    }
=======

	}
>>>>>>> vunt

}
