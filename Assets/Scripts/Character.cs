using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int health;
    [SerializeField] private GameObject healthBarPrefab;

    private HealthBar healthBar;
    private Transform mainCamera;

    public int Health
    { 
        get => health;
        set => health = (value < 0) ? 0: value;
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} | Health : {this.Health}");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main.transform;

        if (healthBarPrefab != null)
        {
            GameObject hbObj = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            healthBar = hbObj.GetComponent<HealthBar>();
            healthBar.SetMaxHealth(startHealth);
            healthBar.SetHealth(startHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} take damage {damage}! | Current HP : {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead! Got destroyed!");
            return true;
        }
        else return false;
    }

    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.transform.position = transform.position + Vector3.up * 1.5f;
            healthBar.transform.rotation = Quaternion.LookRotation(mainCamera.forward);
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(Health);
        }
    }
}