using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement playerMovement;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject lastestChunk;
    public float maxOpDist;//Mas grande que el tamaño del chunk
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;


    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement no encontrado en la escena.");
        }
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!currentChunk) {
            return;
        }

        if (playerMovement == null) return;

        float px = playerMovement.moveDir.x;
        float py = playerMovement.moveDir.y;

        if (px > 0 && py == 0) // DERECHA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRight").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
        }
        else if (px < 0 && py == 0) // IZQUIERDA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightLeft").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            }
        }
        else if (px == 0 && py > 0) // ARRIBA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightLeft").position;
                SpawnChunk();
            }
        }
        else if (px == 0 && py < 0) // ABAJO
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRight").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            }
        }
        else if (px > 0 && py > 0) // ARRIBA DERECHA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (px > 0 && py < 0) // ABAJO DERECHA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRight").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (px < 0 && py > 0) // ARRIBA IZQUIERDA
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightLeft").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (px < 0 && py < 0) // ABAJO IZQUIERDA (corrección)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }

        }

    }

    void SpawnChunk()
    {
      int rand = Random.Range(0, terrainChunks.Count);
        lastestChunk=(Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity));
        spawnedChunks.Add(lastestChunk);
    }
    void ChunkOptimizer() { 
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else {
            return;

        }
            foreach (GameObject chunk in spawnedChunks)
            {
                opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
                if (opDist > maxOpDist)
                {
                    chunk.SetActive(false);
                }
                else
                {
                    chunk.SetActive(true);
                }
            }
    }
}