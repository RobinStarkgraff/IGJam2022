using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float jumpHeight = 5;
    public Vector3 defaultPosition = Vector3.zero;

    private float _totalJumpDuration = 0;
    private float _lastJumpTimeStamp = -1000;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float timeSinceLastJump = Time.time - _lastJumpTimeStamp;
        if (timeSinceLastJump > _totalJumpDuration)
        {
            this.transform.position = defaultPosition;
            return;
        }

        float currentHeight = (jumpHeight * 2 / (float)Math.Pow(_totalJumpDuration, 2)) * (float)Math.Pow(timeSinceLastJump, 2) - jumpHeight * 2 * timeSinceLastJump / _totalJumpDuration;
        
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y - currentHeight * 2, defaultPosition.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You are Dead!");
    }

    public void Jump(float duration)
    {
        _totalJumpDuration = duration;
        _lastJumpTimeStamp = Time.time;
    }

    public void Shoot()
    {
        GameObject projectile = new GameObject();
        projectile.AddComponent<Collider2D>();
        LevelEvent levelEvent = projectile.AddComponent<LevelEvent>();
        levelEvent.startPoint = defaultPosition;
        levelEvent.endPoint = defaultPosition + new Vector3();
    }
}
