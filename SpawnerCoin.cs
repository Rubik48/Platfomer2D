using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoits;
    
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Coin") == false)
        {
            int spawnPoint = Random.Range(0, _spawnPoits.Length);
            
            Instantiate(_coin, _spawnPoits[spawnPoint].position, Quaternion.identity);         
        }
    }
}