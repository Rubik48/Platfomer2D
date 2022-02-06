using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        int _spawnPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_coin, _spawnPoints[_spawnPoint].position, Quaternion.identity);
    }
}