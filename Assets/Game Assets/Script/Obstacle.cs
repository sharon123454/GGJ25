using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Floor myFloor;
    public Floor MyFloor => myFloor;

    private void OnDisable()
    {
        
    }

}