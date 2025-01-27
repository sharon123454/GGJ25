using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private RunChunkGeneration[] chunckRows;

    private float counter = 15f;

    private void Update()
    {
        counter -= Time.deltaTime;
        if (counter < 0)
        {
            for (int i = 0; i < chunckRows.Length; i++)
            {
                chunckRows[i].SetChunckSpeedModifier(chunckRows[i].SpeedModifier + 0.25f);
                counter = 15f;
            }
        }

    }

}