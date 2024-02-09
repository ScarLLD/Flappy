using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _timeToDestroy;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeToDestroy);
    }

    private void Start()
    {
        StartCoroutine(Liquidate());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private IEnumerator Liquidate()
    {
        yield return _waitForSeconds;
        Destroy(gameObject);
    }
}
