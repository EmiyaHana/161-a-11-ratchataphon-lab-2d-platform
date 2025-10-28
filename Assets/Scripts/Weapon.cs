using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public IShootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Character character);

    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }
}