using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SelectMap : MonoBehaviour
{
    [Inject] private readonly SetupWorld _setupWorld;
    
    public void RaceSelect()
    {
        SceneManager.LoadScene(Scenes.RACE_SCENE);
        _setupWorld.SetupRace(true);
    }
    
    public void FreeModeSelect()
    {
        SceneManager.LoadScene(Scenes.FREEMODE_SCENE);
        _setupWorld.SetupRace(false);
    }
}