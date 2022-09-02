using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagert : MonoBehaviour
{

    public Text text;
    private Spawner spawner;
    private Blade blade;
    public Image fadeImage;
    public AudioSource audioSource;
    private int score;
    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        fadeImage = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        spawner = FindObjectOfType<Spawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        newGame();
        
    }

    private void newGame()
    {
        blade.enabled = true;
        spawner.enabled = true;
        score = 0;
        text.text = score.ToString();
        Time.timeScale = 1f;
        ClearScene();
    }
    public void IncreseScore()
    {
        score++;
        text.text = score + "";
    }
    private void ClearScene()
    {
        Fruit[] fruit = FindObjectsOfType<Fruit>();
        foreach (Fruit fr in fruit)
        {
            Destroy(fr.gameObject);
        }
        Bomb[] bomb = FindObjectsOfType<Bomb>();
        foreach (Bomb fr in bomb)
        {
            Destroy(fr.gameObject);
        }

    }
    public void Explode()
    {
        audioSource.Play();
        blade.enabled = false;
        spawner.enabled = false;
        StartCoroutine(Fadeing());

    }
    private IEnumerator Fadeing()
    {
        float elapesed = 0f;
        float duratoin = 5f;
        while(elapesed > duratoin)

        {
            float t = Mathf.Clamp01(elapesed / duratoin);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);
            Time.timeScale = 1f - t;
            elapesed += Time.unscaledDeltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1);

        newGame();
        elapesed = 0f;
        while (elapesed > duratoin)

        {
            float t = Mathf.Clamp01(elapesed / duratoin);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);
            Time.timeScale = 1f - t;
            elapesed += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
