using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _initialPoolSize = 20;

    private List<GameObject> _pool;

    private void Awake()
    {
        _pool = new();
        InitializePool();
    }

    public int GetPoolSize() { return _pool.Count; }
    public GameObject GetFromPool(Vector3 newPos)
    {
        if (_pool.Count < 1) return Instantiate(_prefab, newPos, Quaternion.identity);

        GameObject gameObject = _pool[0];
        gameObject.gameObject.SetActive(true);
        gameObject.transform.position = newPos;
        _pool.Remove(gameObject);
        return gameObject;
    }
    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.zero;
        _pool.Add(gameObject);
    }

    private void InitializePool()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            GameObject newGameObject = Instantiate(_prefab, transform);
            newGameObject.gameObject.SetActive(false);
            _pool.Add(newGameObject);
        }
    }

}