using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public Image healthBar;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (healthBar)
            healthBar.fillAmount = (float)currentHP / maxHP;

        if (currentHP <= 0)
        {
            Debug.Log("Player Dead");
            // 這裡可以做 Game Over 或死亡動畫
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // 敵人碰撞造成傷害
        }
    }
}
