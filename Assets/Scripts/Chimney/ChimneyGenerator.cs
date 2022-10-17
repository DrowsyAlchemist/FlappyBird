using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] protected float _minSpawnPosition;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnDelay)
        {
            if (TryGetObject(out GameObject chimney))
            {
                _elapsedTime = 0;
                float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);
                chimney.transform.position = spawnPoint;

                DisableObjectsAbordScreen();
            }
        }
    }
}
