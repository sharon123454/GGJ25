using UnityEngine;

public enum Floor { low, medium, high }
public class Chunck : MonoBehaviour
{
    public Transform[] ChunckSpawnPoints { get => spawnPositions; private set { } }

    [SerializeField] private Transform[] spawnPositions;

    public void SetupChunck(Floor floorLevel)
    {
        switch (floorLevel)
        {
            case Floor.low:
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    float rand = Random.Range(0, 2);
                    switch (rand)
                    {
                        case 0:
                            break;
                        case 1:
                            print("position mound");
                            ChunkItems.Instance.moundPooler.GetFromPool(spawnPositions[i - 1].position);
                            break;
                        case 2:
                            print("position coral");
                            ChunkItems.Instance.coralPooler.GetFromPool(spawnPositions[i].position);
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Floor.medium:
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    float rand = Random.Range(0, 1);
                    switch (rand)
                    {
                        case 0:
                            break;
                        case 1:
                            print("position puffer");
                            ChunkItems.Instance.pufferPooler.GetFromPool(spawnPositions[i].position);
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Floor.high:
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    float rand = Random.Range(0, 1);
                    switch (rand)
                    {
                        case 0:
                            break;
                        case 1:
                            print("position hook");
                            ChunkItems.Instance.hookPooler.GetFromPool(spawnPositions[i].position);
                            break;
                        default:
                            break;
                    }
                }
                break;
        }
    }

}