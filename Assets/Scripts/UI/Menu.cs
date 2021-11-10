using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuDisplay;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);        
    }

    private void OnDisable()
    {        
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnMenuButtonClick()
    {
        MenuDisplayActivate();
    }

    private void MenuDisplayActivate()
    {
        _menuDisplay.SetActive(true);
        Pause();
    }

    private void OnContinueButtonClick()
    {
        Continue();
    }

    private void Continue()
    {
        Time.timeScale = 1;
        _menuDisplay.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        Exit();
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void OnRestartButtonClick()
    {
        Restart();
    }

    private void Restart()
    {
        Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    public void GameOverDisplayActivate() 
    {
        _continueButton.gameObject.SetActive(false);
        MenuDisplayActivate();
    }
}
