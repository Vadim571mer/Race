using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class SetupGameplay : MonoBehaviour
{
    [Inject] private readonly SetupWorld _setupWorld;

    [SerializeField] private RCCP_SceneManager _sceneManager;
    [SerializeField] private List<RCCP_CarController> _cars = new();
    [SerializeField] private TMP_Text _startTimerText;
    [SerializeField] private GameObject _startTimerObject;

    private void Awake()
    {
        RCCP_CarController car = Instantiate(_setupWorld.CarController, transform.position, Quaternion.identity);

        _sceneManager.activePlayerVehicle = car;
        
        if (_setupWorld.IsRace)
        {
            car.enabled = false;
            _cars.Add(car);
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            _startTimerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        
        _startTimerText.text = "GO!";
        yield return new WaitForSeconds(1);
        _startTimerText.text = "";
        _startTimerObject.SetActive(false);
        StartCoroutine(GO());
    }

    private IEnumerator GO()
    {
        foreach (var car in _cars)
        {
            car.enabled = true;
        }
        
        _setupWorld.StartRace();
        yield return null;
    }
}