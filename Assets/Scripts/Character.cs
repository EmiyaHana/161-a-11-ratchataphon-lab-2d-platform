using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
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
}