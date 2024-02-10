using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _timeToDestroy;

    private Rigidbody2D _rigidBody2D;
    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidBody2D.velocity = transform.right * _speed;
        Invoke(nameof(Disable), _timeToDestroy);
    }

    private void OnDisable()
    {
        _rigidBody2D.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bird>() == false)
            gameObject.SetActive(false);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
