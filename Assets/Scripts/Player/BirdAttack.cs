using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private GameObject _bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = _bulletPool.GetObject();

            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;
        }
    }
}

