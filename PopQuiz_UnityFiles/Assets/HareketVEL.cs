using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HareketVEL : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Animator anim;
    public Animator pipeAnimator;
    public Animator LevelGecisAnimator;
    public GameObject tekrarButon;
    public GameObject cikisButon;
    public TMP_Text soruText;
    public AudioSource walkSound;
    public SoundManager soundManager;
    public float speed;
    public float jumpForce;
    private float movement;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused == true)
            {
                walkSound.enabled = false;
                anim.SetBool("run", false);
                tekrarButon.SetActive(true);
                cikisButon.SetActive(true);
                Time.timeScale = 0;
            }
            else if (paused == false)
            {
                walkSound.enabled = true;
                anim.SetBool("run", true);
                tekrarButon.SetActive(false);
                cikisButon.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            soundManager.jumpSoundPlay();
            rb2.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //rb2.velocity = new Vector2(-speed, 0);
            movement = -speed;
            walkSound.enabled = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //rb2.velocity = new Vector2(speed, 0);
            movement = speed;
            walkSound.enabled = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("run", true);
        }
        else
        {
            movement = 0;
            walkSound.enabled = false;
            anim.SetBool("run", false);
        }

        rb2.velocity = new Vector2(movement, rb2.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "true")
        {
            Debug.Log("Dogru");
            soundManager.trueSoundPlay();
            pipeAnimator.SetTrigger("showPipe");
        }
        else if (col.transform.tag == "false")
        {
            walkSound.enabled = false;
            soundManager.falseSoundPlay();
            soundManager.marioDeadPlay();
            anim.SetBool("run", false);
            anim.SetTrigger("dead");
            transform.tag = "Untagged";
            this.enabled = false;
            soruText.text = "OYUN  BİTTİ";
            StartCoroutine(GameOver());
            Debug.Log("yanlis");
        }
        else if (col.transform.tag == "nextLevel")
        {
            Debug.Log("Sonraki Seviye");
            soundManager.trueSoundPlay();
            LevelGecisAnimator.SetTrigger("fadeIn");
            StartCoroutine(LoadLevel());
        }
        else if (col.transform.tag == "firstLevel")
        {
            Debug.Log("Sonraki Seviye");
            soundManager.trueSoundPlay();
            LevelGecisAnimator.SetTrigger("fadeIn");
            StartCoroutine(RestartGame());
        }
        else if (col.transform.tag == "quitGame")
        {
            Debug.Log("Sonraki Seviye");
            soundManager.trueSoundPlay();
            LevelGecisAnimator.SetTrigger("fadeIn");
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1.1f);
        Application.Quit();
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(1);
    }
    IEnumerator RestartGame()
    {
        SoruSecici.sorulanSoru.Clear();
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.85f);
        tekrarButon.SetActive(true);
        cikisButon.SetActive(true);
    }
}
