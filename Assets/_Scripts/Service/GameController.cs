using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSceneGuiScript _gui;
    [SerializeField] private Transform _projectilesParent, _objectsParent;

    private ScoreManager _scoreManager;
    private static GameController _instance;

    public Transform ProjectilesParent
    {
        get
        {
            return _projectilesParent;
        }
    }

    public Transform ObjectsParent
    {
        get
        {
            return _objectsParent;
        }
    }

    public static GameController Instance
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
        else if (_instance == this)
        {
            Destroy(gameObject);
        }

        _scoreManager = GetComponent<ScoreManager>();
        _scoreManager.SetGuiScript(_gui);
    }

    public void AddScore(int scoreValue)
    {
        _scoreManager.AddScore(scoreValue);
    }

    public void EndGame()
    {
        Invoke(nameof(ShowEndGamePanel), 1f);
    }

    private void ShowEndGamePanel()
    {
        _gui.ShowEndGamePanel();
    }
    
}
