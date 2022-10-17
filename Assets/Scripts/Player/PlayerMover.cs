using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
