using UnityEngine;

public class spawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _enemyFab;

    private void OnEnable()
    {
        InvokeRepeating("Spawn", 2, 2);
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(_enemyFab);
        enemy.transform.position = transform.position;
    }
}
