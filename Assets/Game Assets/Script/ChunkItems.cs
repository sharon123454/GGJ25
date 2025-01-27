using UnityEngine;

public class ChunkItems : MonoBehaviour
{
    public static ChunkItems Instance;

    public ObjectPooler coralPooler;
    public ObjectPooler moundPooler;
    public ObjectPooler pufferPooler;
    public ObjectPooler hookPooler;
    public ObjectPooler airPooler;

    private void Start()
    {
        if (Instance != this && Instance != null) { Destroy(gameObject); }

        Instance = this;
    }

}