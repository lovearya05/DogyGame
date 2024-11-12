using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;

    bool gameStarted = false;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted){
            gameStarted = true;
            StartSpawning();
            tapText.SetActive(false);
        }
    }

    private void StartSpawning(){
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }
    private void SpawnBlock() {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }


}
