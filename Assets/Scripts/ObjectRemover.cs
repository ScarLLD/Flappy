using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private ObjectPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemyPool.PutObject(enemy.gameObject);
        } 
        else if (other.TryGetComponent(out  Bullet bullet)) 
        {
            _bulletPool.PutObject(bullet.gameObject);

        }
    }
}