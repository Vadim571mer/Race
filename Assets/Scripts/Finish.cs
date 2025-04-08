using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;
    
    private bool _isActivated = false; 
    private bool _isFinished = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);
        _isActivated = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!_isActivated)
            return;

        if (_isFinished) 
            return;

        if (other.CompareTag("Player"))
        {
            _win.SetActive(true);
            Debug.Log("Поздравляем! Вы финишировали первым!");
        }
        
        if (other.CompareTag("AI"))
        {
            _lose.SetActive(true);
            Debug.Log("Вы проиграли. Попробуйте еще раз!");
        }

        StartCoroutine(GoMainMenu());

        _isFinished = true; 
    }
    
    private IEnumerator GoMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}