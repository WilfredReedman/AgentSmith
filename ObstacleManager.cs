using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float colorSpeed;
    public GameObject obstaclePrefab;
    public float frequency;
    public Transform player;
    public Player playerPlayer;
    public float diameter;
    public float createDistance;
    public float minScale;
    public float maxSacle;
    private void Start()
    {
        StartCoroutine(CreateObstacles());
        foreach (Obstacles obstacles in GetComponentsInChildren<Obstacles>())
        {
            obstacles.speed = colorSpeed;
        }
    }
    IEnumerator CreateObstacles()
    {
        while (true)
        {
            CreateObject(new Vector2(Random.Range(-diameter, diameter), Random.Range(-diameter, diameter)), Random.Range(minScale, maxSacle));
            yield return new WaitForSeconds((1/ frequency) / (playerPlayer.stage * playerPlayer.accelleration));
        }
    }
    // Start is called before the first frame update
    void CreateObject(Vector2 position, float scale)
    {
        GameObject obstaclePrefabInstance = Instantiate(obstaclePrefab);
        obstaclePrefabInstance.transform.position = new Vector3(position.x, player.position.y - createDistance, position.y);
        obstaclePrefabInstance.transform.localScale = new Vector3(1, scale, 1);
        obstaclePrefabInstance.transform.parent = transform;
        Obstacles obstaclesScript = obstaclePrefabInstance.AddComponent<Obstacles>();
        obstaclesScript.speed = colorSpeed;
    }
}
