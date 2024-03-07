using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float maxMoveLeft;
    private float maxMoveRight;

    private void Awake()
    {
        maxMoveLeft = transform.position.x - movementDistance;
        maxMoveRight = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(transform.position.x > maxMoveLeft)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(3,3, 3);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < maxMoveRight)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-3, 3, 3);
            }
            else
            {
                movingLeft = true;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
