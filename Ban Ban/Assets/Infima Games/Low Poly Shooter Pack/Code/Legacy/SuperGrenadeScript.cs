using System.Collections;
using UnityEngine;

public class SuperGrenadeScript : MonoBehaviour
{
    [Header("Timer")]
    //Time before the grenade explodes
    [Tooltip("Time before the grenade explodes")]
    public float grenadeTimer = 5.0f;

    [Header("Explosion Prefabs")]
    //Explosion prefab
    public Transform explosionPrefab;

    [Header("Throw Force")]
    [Tooltip("Minimum throw force")]
    public float minimumForce = 1500.0f;

    [Tooltip("Maximum throw force")]
    public float maximumForce = 2500.0f;

    private float throwForce;

    [Header("Audio")]
    public AudioSource impactSound;

    private void Awake()
    {
        //Generate random throw force
        //based on min and max values
        throwForce = Random.Range
            (minimumForce, maximumForce);

        //Random rotation of the grenade
        GetComponent<Rigidbody>().AddRelativeTorque
        (Random.Range(500, 1500), //X Axis
            Random.Range(0, 0), //Y Axis
            Random.Range(0, 0) //Z Axis
            * Time.deltaTime * 5000);
    }

    private void Start()
    {
        //Launch the projectile forward by adding force to it at start
        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * throwForce);

        //Start the explosion timer
        StartCoroutine(ExplosionTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Play the impact sound on every collision
        impactSound.Play();
    }

    private IEnumerator ExplosionTimer()
    {
        //Wait set amount of time
        yield return new WaitForSeconds(grenadeTimer);

        RaycastHit checkGround;
        if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
        {
            //Instantiate metal explosion prefab on ground
            Instantiate(explosionPrefab, checkGround.point,
                Quaternion.FromToRotation(Vector3.forward, checkGround.normal));
        }

        var healthPoints = FindObjectsOfType<HealthPoints>();

        foreach (var health in healthPoints) 
        {
            if (health.CompareTag("Enemy"))
                health.TakeDamage(health.CurrentHealth);
        }

        //Destroy the grenade object on explosion
        Destroy(gameObject);
    }
}