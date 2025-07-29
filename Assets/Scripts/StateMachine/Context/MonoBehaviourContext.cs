using UnityEngine;

public class MonoBehaviourContext
{
    public Transform Transform { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public MonoBehaviourContext(Transform transform, Rigidbody2D rigidbody, Animator animator)
    {
        Transform = transform;
        Rigidbody = rigidbody;
        Animator = animator;
    }
}