using UnityEngine;
using Bot;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected int damage = 20;

    public override void Attack(GameObject targetObj)
    {
        if (IsAttacking) return;
        targetObj.GetComponent<HealthPoints>().TakeDamage(damage);
        _animator.SetTrigger("Attack");
        StartCoroutine(WaitingForAttackAnimationToEnd());
    }
}
