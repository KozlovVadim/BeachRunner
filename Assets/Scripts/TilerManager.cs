using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilerManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -5.0f;
    private float tilelength = 10.0f;
    private int amountTiles = 5;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTitles;

	// Use this for initialization
	private void Start () {
        activeTitles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountTiles; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else 
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	private void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - amountTiles * tilelength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject gameObject;
        if (prefabIndex == -1)
            gameObject = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            gameObject = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += tilelength;
        activeTitles.Add(gameObject);
    }

    private void DeleteTile()
    {
        Destroy(activeTitles[0]);
        activeTitles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

            int randomIndex = lastPrefabIndex;
            while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
        
    }
}
