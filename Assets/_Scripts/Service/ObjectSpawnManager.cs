using System.Collections;
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnValues;
    [SerializeField] private GameObject[] _hazards;
    [SerializeField] private int _hazardCount = 15;
    [SerializeField] private float _hazardSpawnWait = 0.7f, _hazardStartWait = 1f, _hazardWaveWait = 5f;

    [SerializeField] private GameObject[] _bonuses;
    [SerializeField] private int _bonusCount = 2;
    [SerializeField] private float _bounsSpawnWait = 0.7f, _bonusStartWait = 30f, _bonusWaveWait = 30f;

    private void Start()
    {
        StartCoroutine(SpawnObject(_hazards, _hazardCount, _hazardSpawnWait, _hazardStartWait, _hazardWaveWait));
        StartCoroutine(SpawnObject(_bonuses, _bonusCount, _bounsSpawnWait, _bonusStartWait, _bonusWaveWait));
    }

    private IEnumerator SpawnObject(GameObject[] objects, int objectsCount, float objectSpawnWait, float objectStartWait, float objectWaveWait)
    {
        yield return new WaitForSeconds(objectStartWait);

        while (true)
        {
            for (int i = 0; i < objectsCount; i++)
            {
                GameObject spawnedObject = objects[Random.Range(0, objects.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-_spawnValues.x, _spawnValues.x), _spawnValues.y, _spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject newObject = Instantiate(spawnedObject, spawnPosition, spawnRotation);
                newObject.transform.parent = GameController.Instance.ObjectsParent;
                yield return new WaitForSeconds(objectSpawnWait);
            }
            yield return new WaitForSeconds(objectWaveWait);
        }
    }

}
