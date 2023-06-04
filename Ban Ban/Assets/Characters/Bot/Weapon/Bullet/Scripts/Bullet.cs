using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

namespace Bot
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage = 5;

        [Range(5, 100)]
        [Tooltip("After how long time should the bullet prefab be destroyed?")]
        public float destroyAfter;

        [Tooltip("If enabled the bullet destroys on impact")]
        public bool destroyOnImpact = false;

        [Tooltip("Minimum time after impact that the bullet is destroyed")]
        public float minDestroyTime;

        [Tooltip("Maximum time after impact that the bullet is destroyed")]
        public float maxDestroyTime;

        public int Damage { get { return damage; } }

        private void Start()
        {
            //Start destroy timer
            StartCoroutine(DestroyAfter());
        }

        //If the bullet collides with anything
        private void OnCollisionEnter(Collision collision)
        {
            //Ignore collisions with other projectiles.
            if (collision.gameObject.GetComponent<Bullet>() != null)
                return;

            //If destroy on impact is false, start 
            //coroutine with random destroy timer
            if (!destroyOnImpact)
            {
                StartCoroutine(DestroyTimer());
            }

            //Otherwise, destroy bullet on impact
            else
            {
                Destroy(gameObject);
            }

            if (collision.transform.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }

            else if (collision.transform.CompareTag("Player"))
            {
                collision.transform.gameObject.GetComponent
                    <HealthPoints>().TakeDamage(damage);

                Destroy(gameObject);
            }
        }

        private IEnumerator DestroyTimer()
        {
            //Wait random time based on min and max values
            yield return new WaitForSeconds
                (Random.Range(minDestroyTime, maxDestroyTime));
            //Destroy bullet object
            Destroy(gameObject);
        }

        private IEnumerator DestroyAfter()
        {
            //Wait for set amount of time
            yield return new WaitForSeconds(destroyAfter);
            //Destroy bullet object
            Destroy(gameObject);
        }
    }
}