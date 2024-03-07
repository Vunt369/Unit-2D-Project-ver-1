using UnityEngine;

public class LizardDamage : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject[] fireball;
    [SerializeField] private Transform firepoint;
    private Animator animator;
    private float cooldownTime = 0; // Thay đổi giá trị ban đầu thành 0

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Tăng cooldownTime sau mỗi frame
        cooldownTime += Time.deltaTime;

        // Kiểm tra nếu cooldownTime vượt quá attackCooldown, cho phép quái tấn công
        if (cooldownTime >= attackCooldown)
        {
            EnemyAttack();
            // Reset cooldownTime
            cooldownTime = 0;
        }
    }

    private void EnemyAttack()
    {
        animator.SetTrigger("attack");

        int index = FindFireBall();
        if (index != -1)
        {
            // Lấy ra fireball được tìm thấy
            GameObject newFireball = fireball[index];

            // Thiết lập vị trí của fireball theo vị trí của firepoint
            newFireball.transform.position = firepoint.position;

            // Xác định hướng của viên đạn dựa trên hướng của quái
            float direction = Mathf.Sign(transform.localScale.x);

            // Đặt hướng cho viên đạn
            newFireball.GetComponent<FireBallController>().SetDirection(direction);

            // Kích hoạt fireball
            newFireball.SetActive(true);
        }
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireball.Length; i++)
        {
            if (!fireball[i].activeSelf)
                return i;
        }
        return -1; // Trả về -1 nếu không tìm thấy viên đạn nào được không hoạt động
    }
}
