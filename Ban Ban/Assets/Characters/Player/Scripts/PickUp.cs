using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Medicine Chest"))
        {
            var health = GetComponent<HealthPoints>();
            health.TakeHealth(health.MaxHealth);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PartSpaceShip"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ammunition"))
        {
            other.GetComponent<AmmunitionShop>().ReplenishAmmunition();
            Destroy(other.gameObject);
        }
    }
}
