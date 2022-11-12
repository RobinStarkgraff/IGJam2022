using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float jumpHeight = 5;
    public Vector3 defaultPosition = Vector3.zero;

    private float _totalJumpDuration = 0;
    private float _lastJumpTimeStamp = -1000;

    private Animator _animator;
    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float timeSinceLastJump = Time.time - _lastJumpTimeStamp;
        if (timeSinceLastJump > _totalJumpDuration)
        {
            _animator.SetBool("isJumping", false);
            //running Animation
            this.transform.position = defaultPosition;
            return;
        }

        // float currentHeight = (-2 * jumpHeight * timeSinceLastJump / totalJumpDuration) + 2 * jumpHeight;
        
        float currentHeight = (jumpHeight * 2 / (float)Math.Pow(_totalJumpDuration, 2)) * (float)Math.Pow(timeSinceLastJump, 2) - jumpHeight * 2 * timeSinceLastJump / _totalJumpDuration;
        
        // Debug.Log((float)Math.Pow(2 * totalJumpDuration, 2) + "   a");
        // Debug.Log((float)Math.Pow(timeSinceLastJump, 2) + "   b");
        // Debug.Log(currentHeight + "Height");
        _animator.SetBool("isJumping", true);
        //Jump Animation
        
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y - currentHeight * 2, defaultPosition.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You are Dead!");
    }

    public void Jump(float duration)
    {
        Debug.Log("Jump!");
        _totalJumpDuration = duration;
        _lastJumpTimeStamp = Time.time;
    }
}
