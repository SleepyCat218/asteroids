using UnityEngine;
using UnityEngine.UI;

public class StartSceneGuiScript : MonoBehaviour
{
    [SerializeField] private Button _startGame, _exitGame;

    private void Start()
    {
        _startGame.onClick.AddListener(GameManager.Instance.StartGame);
        _exitGame.onClick.AddListener(GameManager.Instance.ExitGame);
    }
}
