using UnityEngine;
using Zenject;

public class SelectCar : MonoBehaviour
{
    [Inject] private readonly SetupWorld _setupWorld;
    
    [SerializeField] private RCCP_CarController[] _cars;

    public void Select(int carIndex)
    {
        _setupWorld.SetupCar(_cars[carIndex]);
    }
}