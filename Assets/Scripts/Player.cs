using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private GameObject _prefabProjectile;

    [NonSerialized] public float jumpHeight = 2.5f;
    public Vector3 defaultPosition = Vector3.zero;

    private float _totalJumpDuration = 0;
    private float _lastJumpTimeStamp = -1000;

    public Canvas _gameOver;
    public GameObject _retry;
    public GameObject Score;
    public TMP_Text ScoreText;
    private Animator _animator;
    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float timeSinceLastJump = Time.timeSinceLevelLoad - _lastJumpTimeStamp;
        float totalJumpDuration = _totalJumpDuration * 20 / GameController.Instance.GetGameSpeed();
        if (timeSinceLastJump > totalJumpDuration)
        {
            _animator.SetBool("isJumping", false);
            //running Animation
            this.transform.position = defaultPosition;

            return;
        }

        float currentHeight = (jumpHeight * 2 / (float)Math.Pow(totalJumpDuration, 2)) * (float)Math.Pow(timeSinceLastJump, 2) - jumpHeight * 2 * timeSinceLastJump / totalJumpDuration;
        
        
        _animator.SetBool("isJumping", true);
        //Jump Animation
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y - currentHeight * 2, defaultPosition.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    public void Die()
    {
        Debug.Log("You are Dead!");
        _gameOver.gameObject.SetActive(true);
        ScoreText.text = GameController.Instance.ScoreText.text;
        _retry.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Jump(float duration)
    {
        _totalJumpDuration = duration;
        _lastJumpTimeStamp = Time.timeSinceLevelLoad;
    }
}
