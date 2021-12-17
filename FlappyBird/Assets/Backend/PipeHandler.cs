using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeHandler : MonoBehaviour
{

    public GameObject pipe;
    public GameObject ground;
    public GameObject bird;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public Text _countdownText;
    public float height;
    public float maxTime = 1;
    public float timer = 0;
    public float speed;

    private List<Pipe> pipeList;

    private State state;

    private enum State
    {
        WaitinfToStart,
        Playing,
        Pause,
        BirdDead,
    }

    private void Awake()
    {
        pipeList = new List<Pipe>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Bird.GetInstance().OnDied += Pipe_OnDied;
        Bird.GetInstance().OnStartedPlaying += Pipe_OnStartedPlaying;
        Bird.GetInstance().OnPause += Pipe_OnPause;
        Bird.GetInstance().OnResume += Pipe_OnResume;
    }

    private void Pipe_OnResume(object sender, System.EventArgs e)
    {
        StartCoroutine(CountdownToResume());        
    }

    private void Pipe_OnPause(object sender, System.EventArgs e)
    {
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
        state = State.Pause;
        ground.GetComponent<Animator>().enabled = false;
        bird.GetComponent<Animator>().enabled = false;
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void Pipe_OnStartedPlaying(object sender, System.EventArgs e)
    {
        state = State.Playing;
        ground.GetComponent<Animator>().enabled = true;
        bird.GetComponent<Animator>().enabled = true;
    }

    private void Pipe_OnDied(object sender, System.EventArgs e)
    {
        state = State.BirdDead;
        ground.GetComponent<Animator>().enabled = false;
        bird.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Playing)
        {
            HandlePipeSpawning();
            HandlePipeMovement();
        }
    }

    private void HandlePipeSpawning()
    {
        if (timer > maxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Pipe pipeclass = new Pipe(newpipe, speed);
            pipeList.Add(pipeclass);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void HandlePipeMovement()
    {
        for(int i = 0; i<pipeList.Count; i++)
        {
            Pipe pipeclass = pipeList[i];
            pipeclass.Move();

            if (pipeList.Count == 5)
            {
                pipeclass.DestroySelf();
                pipeList.Remove(pipeclass);
                i--;
            }
        }
        
    }

    IEnumerator CountdownToResume()
    {

        int countdown = 4;
        _countdownText.gameObject.SetActive(true);
        resumeButton.SetActive(false);
        SoundManager.PlaySound(SoundManager.Sound.CountdownSound);

        while (countdown > 0)
        {
            if ((countdown - 1) != 0)
                _countdownText.text = (countdown - 1).ToString();
            else
            {
                _countdownText.text = "Start!";
                pauseButton.SetActive(true);
                state = State.Playing;
                ground.GetComponent<Animator>().enabled = true;
                bird.GetComponent<Animator>().enabled = true;
                bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Bird.GetInstance().GetComponent<AudioSource>().Play();
            }

            yield return new WaitForSeconds(1f);

            countdown--;
        }

        _countdownText.gameObject.SetActive(false);
        
    }


    private class Pipe
    {
        private GameObject pipe;
        private float speed;

        public Pipe(GameObject pipeObject, float speed)
        {
            pipe = pipeObject;
            this.speed = speed;
        }

        public void Move()
        {
            pipe.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        public void DestroySelf()
        {
            Destroy(pipe);
        }
    }
}
