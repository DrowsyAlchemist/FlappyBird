using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            GameObject spawned = Instantiate(prefab, position, Quaternion.identity, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        if (result != null)
        {
            result.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void DisableObjectsAbordScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(Vector2.zero);

        foreach (var item in _pool)
            if (item.activeSelf == true)
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
