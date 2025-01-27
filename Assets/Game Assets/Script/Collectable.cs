using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Floor myFloor;
    public Floor MyFloor => myFloor;

    private void OnDisable()
    {
        
    }

}