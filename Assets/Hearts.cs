using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public int hearts = 3;
    public TextMeshProUGUI heartsText;
    public float seconds = 3f;
	public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        heartsText.SetText(hearts.ToString());
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
        if(seconds == 3f)
        {
            animator.SetBool("hurt", false);
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemies") && seconds == 3f)
        {
            hearts = hearts - 1;
            heartsText.SetText(hearts.ToString());
            seconds = 0;
            animator.SetBool("hurt", true);
        }
	}

}
