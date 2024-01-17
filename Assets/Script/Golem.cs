using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : MonoBehaviour
{
    [Header("*Health*")]
    public static int Bosshealth = 30;
    public Slider healthBar;

    [Header("*Health")]
    bool isAlive;
    bool platformCheck;

    [Header("*Objects*")]
    public GameObject slime;
    public GameObject boss;
    [SerializeField] Transform spawnLeft;
    [SerializeField] Transform spawnRight;
    [SerializeField] Transform spawnMiddle;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject bg;
    public ParticleSystem death;
    public Transform slimeP;

    [Header("*Audio*")]
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource slimeAudio;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.projectileActive = true;
        isAlive = true;
        StartCoroutine(BossActionRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = Bosshealth;
        if (Bosshealth == 0)
        {
            isAlive = false;
            boss.SetActive(false);
            healthBar.gameObject.SetActive(false);
            death.Play();
            platform.SetActive(false);
            platform1.SetActive(false);
            slimeP.gameObject.SetActive(false);
            bg.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Bosshealth--;
            hurt.Play();
            Debug.Log(Bosshealth);
        }
    }

    private IEnumerator MakePlatformDisappear()
    {
        platform.SetActive(false);
        platform1.SetActive(false);
        yield return new WaitForSeconds(3f);
        platform.SetActive(true);
        platform1.SetActive(true);
    }

    private void SpawnSlimes()
    {
        slimeAudio.Play();

        GameObject slimeLeft =  Instantiate(slime, spawnLeft.position, Quaternion.identity);
        GameObject slimeRight = Instantiate(slime, spawnRight.position, Quaternion.identity);

        slimeLeft.transform.SetParent(slimeP);
        slimeRight.transform.SetParent(slimeP);
    }

    private IEnumerator BossActionRoutine()
    {
        while (isAlive)
        {
            float randomAction = Random.Range(0f, 1f);
            if (randomAction < 0.5f)
            {
                SpawnSlimes();
            }
            else
            {
                StartCoroutine(MakePlatformDisappear());
            }

            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }  
    }

}   

   

