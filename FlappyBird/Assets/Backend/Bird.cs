using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    public GameObject Handling;
    public GameObject ScoreBoard;
    private float _topBorder;
    public float jumpVelocity = 1;

    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;
    public event EventHandler OnPause;
    public event EventHandler OnResume;

    private static Bird instance;

    [SerializeField] public LayerMask obstaclesMaskLayer;
    bool lastHit = false;
    private int counter;
    private State state;

    private enum State
    {
        WaitingToStart,
        Playing,
        Pause,
        BirdDead,
    }

    public static Bird GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _topBorder = Camera.main.orthographicSize - _rigidbody2D.gameObject.GetComponent<Renderer>().bounds.size.y;
        JumpUp();

        state = State.WaitingToStart;
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            default:
            case State.WaitingToStart:
                if (Input.GetMouseButtonDown(0) && _rigidbody2D.position.y <= _topBorder)
                {
                    state = State.Playing;
                    GetComponent<AudioSource>().Play();
                    _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    ScoreBoard.SetActive(true);
                    Handling.SetActive(false);
                    JumpUp();
                    if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetMouseButtonDown(0) && _rigidbody2D.position.y <= _topBorder)
                {
                    JumpUp();
                }
                break;
            case State.BirdDead:
                break;
        }
        

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.up, 100f, obstaclesMaskLayer);
        if (raycastHit2D.collider != null && !lastHit)
        {
            counter++;
            SoundManager.PlaySound(SoundManager.Sound.Point);
            Debug.Log($"score is: {counter}");
        }
        lastHit = raycastHit2D;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        state = State.BirdDead;
        GetComponent<AudioSource>().Stop();
        SaveData.SaveTheData();
        if (OnDied != null) OnDied(this, EventArgs.Empty);
        SoundManager.PlaySound(SoundManager.Sound.BirdDie);
    }

    public int GetScore()
    {
        return counter;
    }

    public void JumpUp()
    {
        _rigidbody2D.velocity = Vector2.up * jumpVelocity;
        SoundManager.PlaySound(SoundManager.Sound.BirdJump);
    }

    public void Pause()
    {
        if (OnPause != null) OnPause(this, EventArgs.Empty);
        GetComponent<AudioSource>().Pause();
    }

    public void Resume()
    {
        if (OnResume != null) OnResume(this, EventArgs.Empty);
    }

}
