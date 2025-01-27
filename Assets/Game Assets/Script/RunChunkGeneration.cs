using System.Collections.Generic;
using UnityEngine;

public class RunChunkGeneration : MonoBehaviour
{
    public float ChunckSpeed { get => moveSpeed * speedModifier; private set { } }
    public float SpeedModifier { get => speedModifier; private set { } }

    [SerializeField] private Floor floorLevel;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private ChunckPooler chunkPooler;
    [SerializeField] private int startChunkAmount = 15;
    [SerializeField] private float chunckLength = 15f;

    private List<Chunck> chunkList = new List<Chunck>();
    private float speedModifier = 1f;

    private void Start()
    {
        SpawnChunksAtStart();
    }
    private void Update()
    {
        MoveChuncks();
    }

    public void SetChunckSpeedModifier(float newSpeedModifier) { speedModifier = newSpeedModifier; }

    private void SpawnChunk()
    {
        Chunck newChunk;

        if (chunkList.Count == 0)
        {
            newChunk = chunkPooler.GetFromPool(transform.position);
            newChunk.SetupChunck(floorLevel);
        }
        else
        {
            Chunck lastChunk = chunkList[chunkList.Count - 1];
            Vector3 chunkSpawnPos = new Vector3(lastChunk.transform.position.x, lastChunk.transform.position.y, lastChunk.transform.position.z + chunckLength);

            newChunk = chunkPooler.GetFromPool(chunkSpawnPos);
            newChunk.SetupChunck(floorLevel);
        }

        chunkList.Add(newChunk);
    }
    private void SpawnChunksAtStart()
    {
        for (int i = 0; i < startChunkAmount; i++) { SpawnChunk(); }
    }

    private void MoveChuncks()
    {
        for (int i = 0; i < chunkList.Count; i++)
        {
            Chunck chunk = chunkList[i];
            chunk.transform.Translate(Vector3.back * (moveSpeed * speedModifier * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunckLength)
            {
                OnChunckDestroyed(chunk);
            }
        }
    }

    private void OnChunckDestroyed(Chunck chunk)
    {
        chunkPooler.ReturnToPool(chunk);
        chunkList.Remove(chunk);

        SpawnChunk();
    }

}