using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private string _gameScene = "GameScene", _startScene = "StartScene";
    private bool _isPaused = false;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
        private set { }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(_startScene);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
    }
}
