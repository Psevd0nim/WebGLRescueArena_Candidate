using System.Collections;
using UnityEngine;

namespace WebGLRescueArena
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private float lifetime = 2.5f;
        [SerializeField] private GameObject fallbackImpactEffect;

        private Rigidbody body;
        private int damage;
        private SimpleObjectPool _projectilePool;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            //Destroy(gameObject, lifetime);
            _projectilePool  = GetComponentInParent<SimpleObjectPool>();
        }

        public void Init(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
            gameObject.SetActive(true);
            StartCoroutine(LifeTimeCoroutine());
        }

        public void  Launch(float speed, int damageValue)
        {
            damage = damageValue;
            body.linearVelocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
            GameObject impact = Resources.Load<GameObject>("Effects/Impact") ?? fallbackImpactEffect;
            if (impact != null)
                Instantiate(impact, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            DeathRattle();
        }

        private void DeathRattle()
        {
            if(_projectilePool != null)
                _projectilePool.Return(gameObject);
        }

        private IEnumerator LifeTimeCoroutine()
        {
            yield return new WaitForSeconds(lifetime);
            DeathRattle();
        }
    }
}
