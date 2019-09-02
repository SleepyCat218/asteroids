using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private GameSceneGuiScript _gui;
    private int _score = 0;

    public void SetGuiScript(GameSceneGuiScript gui)
    {
        _gui = gui;
    }

    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
        _gui.UpdateScore(_score);
    }

    private void Start()
    {
        _gui.UpdateScore(_score);
    }

}
