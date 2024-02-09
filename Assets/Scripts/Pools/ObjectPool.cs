using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _gameObjectPrefab;

    private Queue<GameObject> _pool;

    public IEnumerable<GameObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var gameObject = Instantiate(_gameObjectPrefab);
            gameObject.transform.parent = _container;

            return gameObject;
        }

        return _pool.Dequeue();
    }

    public void PutObject(GameObject gameObject)
    {
        _pool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
