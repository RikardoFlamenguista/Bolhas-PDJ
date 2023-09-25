using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Pools
    {
        public GameObject Bubbles;
        public string tag;
        public int size;
    }

    public Dictionary<string, Queue<GameObject>> bubblesPool;
    public List<Pools> pools;

    [Header("Bubbles")]
    public GameObject bloodBubbles;
    public GameObject spawnPoint;

    public float spawnCd;

    private void Start()
    {


        bubblesPool = new Dictionary<string, Queue<GameObject>>();

        foreach (Pools pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Bubbles);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            bubblesPool.Add(pool.tag, objectPool);
        }


        InvokeRepeating("SpawnBloodBubble", 0, spawnCd);
    }



    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!bubblesPool.ContainsKey(tag))
        {
            Debug.LogWarning("Pool doesn't exist");
            return;
        }

        GameObject objToSpawn = bubblesPool[tag].Dequeue();

        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.SetActive(true);

        // Reenfileira o objeto para ser reutilizado.
        bubblesPool[tag].Enqueue(objToSpawn);
    }

    public void SpawnBloodBubble()
    {
        Vector3 position = spawnPoint.transform.position;
        int randomNumber = UnityEngine.Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                position.x = -2f;
                break;

            case 2:
                position.x = 0;
                break;

            case 3:
                position.x = 2f;
                break;
        }

        SpawnFromPool("bloodBubble", position, Quaternion.identity);

    }
}