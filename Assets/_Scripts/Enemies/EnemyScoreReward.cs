using UnityEngine;

public class EnemyScoreReward : MonoBehaviour
{
    [SerializeField] private int _score;

    public void AddScore()
    {
        GameController.Instance.AddScore(_score);
    }
}
