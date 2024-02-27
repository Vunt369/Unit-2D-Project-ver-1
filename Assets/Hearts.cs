using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public int hearts = 3;
    public TextMeshProUGUI heartsText;
    public float seconds = 5f;
	private float blinkInterval = 0.5f;
	public SpriteRenderer spriteRenderer;
	// Start is called before the first frame update
	void Start()
    {
        heartsText.SetText(hearts.ToString());
    }

    // Update is called once per frame
    void Update()
    {
		if (seconds >= 5f)
		{
			seconds = 5f; // Reset seconds to 0 if it reaches 5x
		}
		else
		{
			seconds += Time.deltaTime; // Increment seconds by the time passed
			Color color = spriteRenderer.color;
			color.a = 0.5f;
			spriteRenderer.color = color;
			if (seconds >= 5f)
			{
				seconds = 5f; // Ensure seconds doesn't go beyond 5
				color.a =1f;
				spriteRenderer.color = color;
			}
		}
        if(hearts == 0)
        {
            Destroy(this.gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemies") && seconds == 5f)
        {
            hearts = hearts - 1;
            heartsText.SetText(hearts.ToString());
            seconds = 0;
        }
	}
   
}
