using System.Collections.Generic;
using UnityEngine;

public class ChunckPooler : MonoBehaviour
{
    [SerializeField] private Chunck _prefab;
    [SerializeField] private int _initialPoolSize = 20;

    private List<Chunck> _pool;

    private void Awake()
    {
        _pool = new();
        InitializePool();
    }

    public Chunck GetFromPool(Vector3 newPos)
    {
        Chunck gameObject = _pool[0];
        gameObject.gameObject.SetActive(true);
        gameObject.transform.position = newPos;
        _pool.Remove(gameObject);
        return gameObject;
    }
    public void ReturnToPool(Chunck gameObject)
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
            Chunck newChunk = Instantiate(_prefab, transform);
            newChunk.gameObject.SetActive(false);
            _pool.Add(newChunk);
        }
    }

}