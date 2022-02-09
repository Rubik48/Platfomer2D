using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        int _spawnPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_coinTemplate, _spawnPoints[_spawnPoint].position, Quaternion.identity);
    }
}