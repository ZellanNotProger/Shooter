using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _positionBullet;
    [SerializeField] private int _maxAmmo = 0;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private float _fireRate = 15f;
    [SerializeField] private float _reloadingTime;

    private float _nextTimeToFire = 0f;
    private readonly string _fireOne = "Fire1";
    private bool isReloading;

    void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown(_fireOne) && Time.time >= _nextTimeToFire && _currentAmmo > 0)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(_reloadingTime);

        _currentAmmo = _maxAmmo;
        isReloading = false;
    }

    private void Shoot()
    {
        _currentAmmo--;
        GameObject bulletObject = Instantiate(_bulletPrefab);
        bulletObject.transform.position = _positionBullet.transform.position + _positionBullet.transform.forward;
        bulletObject.transform.forward = _positionBullet.transform.forward;
    }
}

