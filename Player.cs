using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathScreen;
    public AudioSource music;
    public float test;
    public int stage;
    [Space]
    public float stageLength;
    public float accelleration;
    [Space]
    public float areaDiameter;
    [Space]
    public float fallSpeed;
    public float movementSpeed;
    public float movementSpeedAccelleration;
    bool alive;
    private void Awake()
    {
        alive = true;
        StartCoroutine(StageCounter());

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed;
        float y = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 movement = new Vector3(x, -fallSpeed, y);
        if (!alive)
            movement = new Vector3(0, -fallSpeed, 0);
        transform.Translate(movement * Time.deltaTime);

        if (transform.position.x > areaDiameter)
            transform.position = new Vector3(areaDiameter, transform.position.y, transform.position.z);
        if (transform.position.x < -areaDiameter)
            transform.position = new Vector3(-areaDiameter, transform.position.y, transform.position.z);
        if (transform.position.z > areaDiameter)
            transform.position = new Vector3(transform.position.x, transform.position.y, areaDiameter);
        if (transform.position.z < -areaDiameter)
            transform.position = new Vector3(transform.position.x, transform.position.y, -areaDiameter);
    }
    IEnumerator StageCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(stageLength);
            fallSpeed += accelleration;
            movementSpeed += movementSpeedAccelleration;
            stage++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        Debug.Log("dead");
        music.Stop();
        StopCoroutine(StageCounter());
        alive = false;
        while (true)
        {
            yield return null;
            if (fallSpeed > 0)
                fallSpeed -= 0.5f;
            else
            {
                deathScreen.SetActive(true);
            }
        }
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
