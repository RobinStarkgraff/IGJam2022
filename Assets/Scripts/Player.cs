using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float jumpHeight = 5;
    public Vector3 defaultPosition = Vector3.zero;

    private float totalJumpDuration = 0;
    private float _lastJumpTimeStamp = -1000;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float timeSinceLastJump = Time.time - _lastJumpTimeStamp;
        if (timeSinceLastJump > totalJumpDuration)
        {
            this.transform.position = defaultPosition;
            return;
        }

        // float currentHeight = (-2 * jumpHeight * timeSinceLastJump / totalJumpDuration) + 2 * jumpHeight;
        
        float currentHeight = (jumpHeight * 2 / (float)Math.Pow(totalJumpDuration, 2)) * (float)Math.Pow(timeSinceLastJump, 2) - jumpHeight * 2 * timeSinceLastJump / totalJumpDuration;
        
        // Debug.Log((float)Math.Pow(2 * totalJumpDuration, 2) + "   a");
        // Debug.Log((float)Math.Pow(timeSinceLastJump, 2) + "   b");
        // Debug.Log(currentHeight + "Height");
        
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y - currentHeight * 2, defaultPosition.z);
    }

    public void Jump(float duration)
    {
        Debug.Log("Jump!");
        totalJumpDuration = duration;
        _lastJumpTimeStamp = Time.time;
    }
}
