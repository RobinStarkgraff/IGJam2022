using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private List<Sprite> clouds;


    private float minimumHeight = 1.5f;
    private float maximumHeight = 3;

    private float speed;
    private float minimumSpeed = 0.05f;
    private float maximumSpeed = 0.2f;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = clouds[Random.Range(0, clouds.Count - 1)];
        transform.position = new Vector3(12, Random.Range(minimumHeight, maximumHeight), 0);
        speed = Random.Range(minimumSpeed, maximumSpeed);
    }

    private void Update()
    {
        transform.position -= new Vector3(1, 0, 0) * (speed * GameController.Instance.GetGameSpeed() * Time.timeSinceLevelLoad);
    }
}