using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset = 1;

    private void Update()
    {
        float xPosition = _player.transform.position.x + _xOffset;
        float yPosition = transform.position.y;
        float zPosition = transform.position.z;
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }
}
