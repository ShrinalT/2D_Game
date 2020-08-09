using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemycont;
    [SerializeField]
    private GameObject[] powerups;
    private bool _spwanControl = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpwanPowerupRountine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_spwanControl == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int rand = Random.Range(0, 3);
            GameObject newEnemy = Instantiate(powerups[rand], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,8));
        }
    }
    IEnumerator SpwanEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_spwanControl == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemycont.transform;
            yield return new WaitForSeconds(3.0f);
        }
    }

    public void isPlayerDead()
    {
        _spwanControl = true;
    }
    public void StartSpwan()
    {
        StartCoroutine(SpwanEnemyRoutine());
        StartCoroutine(SpwanPowerupRountine());
    }
}
