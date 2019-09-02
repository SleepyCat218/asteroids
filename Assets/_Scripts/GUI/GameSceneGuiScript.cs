using UnityEngine;
using UnityEngine.UI;

public class GameSceneGuiScript : MonoBehaviour
{
    [SerializeField] private Text _scoreValue;
    [SerializeField] private Transform _pausePanel, _endGamePanel;
    [SerializeField] private Button _pauseButton, _unpauseButton, _restartButton;
    [SerializeField] private Button[] _mainMenuButton;

    public void UpdateScore(int score)
    {
        _scoreValue.text = score.ToString();
    }

    private void Start()
    {
        _pausePanel.gameObject.SetActive(false);
        _endGamePanel.gameObject.SetActive(false);
        _pauseButton.onClick.AddListener(PauseGame);
        _unpauseButton.onClick.AddListener(UnpauseGame);
        _restartButton.onClick.AddListener(GameManager.Instance.StartGame);
        foreach (var item in _mainMenuButton)
        {
            item.onClick.AddListener(GameManager.Instance.ExitToMenu);
        }
    }

    private void PauseGame()
    {
        _pauseButton.interactable = false;
        _pausePanel.gameObject.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    private void UnpauseGame()
    {
        _pauseButton.interactable = true;
        _pausePanel.gameObject.SetActive(false);
        GameManager.Instance.UnpauseGame();
    }

    public void ShowEndGamePanel()
    {
        _pauseButton.interactable = false;
        _endGamePanel.gameObject.SetActive(true);
        GameManager.Instance.PauseGame();
    }
}
