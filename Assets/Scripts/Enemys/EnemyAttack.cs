using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private WaitForSeconds _timeBetwenShot = new WaitForSeconds(2);

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isShooting = true;

        while (isShooting)
        {
            Instantiate(_bullet);
            yield return _timeBetwenShot;
        }
    }
}
