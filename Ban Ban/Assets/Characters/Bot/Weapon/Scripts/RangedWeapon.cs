using UnityEngine;
using Bot;
using System.Collections;

public class RangedWeapon : Weapon
{
    [SerializeField] private int magazineSize = 20;

    [Range(0, 100)]
    [SerializeField] private int hitProbability = 50;
    [SerializeField] private int increaseHitProbabilityPerLevel = 2;

    [Title(label: "Bullet")]

    [SerializeField] private GameObject bulletPrefs;
    [SerializeField] private float bulletImpulse;
    [SerializeField] private Transform barrel;

    [Title(label: "Fire Effects")]

    [SerializeField] private GameObject prefabFlashParticles;
    [SerializeField] private int flashParticlesCount = 5;
    [SerializeField] private AudioSource fireAudioPref;

    private int _restOfBulletInMagazine;
    private ParticleSystem particles;

    private void Start()
    {
        base.Start();
        _restOfBulletInMagazine = magazineSize;
        //Instantiate Particles.
        GameObject spawnedParticlesPrefab = Instantiate(prefabFlashParticles, barrel);
        //Reset the position.
        spawnedParticlesPrefab.transform.localPosition = default;
        //Reset the rotation.
        spawnedParticlesPrefab.transform.localEulerAngles = default;
        particles = spawnedParticlesPrefab.GetComponent<ParticleSystem>();
        hitProbability += Level.CurrentLevel * increaseHitProbabilityPerLevel;
    }

    public override void Attack(GameObject targetObj)
    {
        if (_isReloading) return;
        if (_restOfBulletInMagazine < 1)
        {
            StartCoroutine(Reloading());
            return;
        }
        if (IsAttacking) return;
        Effect();
        _animator.SetTrigger("Attack");
        _restOfBulletInMagazine--;
        StartCoroutine(WaitingForAttackAnimationToEnd());
        if (Random.Range(0, 100) > hitProbability) return;
        var targetAttack = targetObj.transform.position +
            new Vector3(0f, targetObj.GetComponent<CapsuleCollider>().height * 0.9f, 0f) - barrel.transform.position;
        var bullet = Instantiate(bulletPrefs, barrel.position, Quaternion.LookRotation(targetAttack));
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletImpulse;
    }

    public void Effect()
    {
        if (particles != null)
            particles.Emit(flashParticlesCount);
        var fireAudio = Instantiate(fireAudioPref.gameObject, barrel.position, barrel.rotation);
        Destroy(fireAudio, fireAudio.GetComponent<AudioSource>().clip.length);
    }

    private IEnumerator Reloading()
    {
        if (_animator != null) _animator.SetTrigger("Reload");
        _isReloading = true;
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"));
        yield return new WaitForSecondsRealtime(_animator.GetCurrentAnimatorStateInfo(0).length);
        _isReloading = false;
        _restOfBulletInMagazine = magazineSize;
    }
}
