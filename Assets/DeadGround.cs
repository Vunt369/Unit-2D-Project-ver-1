using UnityEngine;

public class DeadGround : MonoBehaviour
{
    public GameObject player;
    public GameObject spawPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawPoint.transform.position;
        }
    }
}
