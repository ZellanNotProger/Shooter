using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 65f;
    [SerializeField] private float _lifeTimer = 2f;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _lifeTimer -= Time.deltaTime;

        if (_lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out var enemy))
        {
            enemy.ApplyDamage(_damage);
        }
    }
}
