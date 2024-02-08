using System;
using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdCollisionHandler : MonoBehaviour
{
    private Health _health;

    public event Action<IInteractable> CollisionDetected;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
            Time.timeScale = 0f;
            Debug.Log("trigger");
        }
    }
}
