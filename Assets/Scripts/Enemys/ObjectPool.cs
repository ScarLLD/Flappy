using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _enemyPrefab;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> EnemyPooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            var enemy = Instantiate(_enemyPrefab);
            enemy.transform.parent = _container;

            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
