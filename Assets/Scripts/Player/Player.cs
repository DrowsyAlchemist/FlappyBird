using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private int _score;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Rigidbody2D _rigidBody;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _rigidBody = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled)
            if (collision.TryGetComponent(out ScoreZone _))
            {
                _score++;
                ScoreChanged?.Invoke(_score);
            }
            else
            {
                Die();
            }
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);

        transform.SetPositionAndRotation(_initialPosition, _initialRotation);
        _rigidBody.velocity = Vector3.zero;
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
