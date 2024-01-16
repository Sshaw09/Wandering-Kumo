using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : MonoBehaviour
{
    int health = 30;
    public Slider healthBar;
    public GameObject slime;
    bool isAlive;
    public GameObject boss;
    [SerializeField] Transform spawnLeft;
    [SerializeField] Transform spawnRight;
    [SerializeField] Transform spawnMiddle;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject platform1;
    public ParticleSystem death;
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
        healthBar.value = health;

        if (health == 0)
        {
            isAlive = false;
            boss.SetActive(false);
            Destroy(healthBar);
            death.Play();
            Debug.Log("Blud is died, RIP BOZO");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health--;
            Debug.Log(health);
        }
    }

    private IEnumerator BossActionRoutine()
    {
        while (isAlive)
        {
            float randomAction = Random.Range(0f, 1f);
            float randomArrow = Random.Range(0f, 5f);
            Debug.Log(randomAction);
            if (randomAction < 0.5f)
            {
                SpawnSlimes();
                //SpawnArrow();
            }
            else
            {
                StartCoroutine(MakePlatformDisappear());
            }

            yield return new WaitForSeconds(Random.Range(5f, 7f));
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
        Debug.Log("Spawn Slimes");
        Instantiate(slime, spawnLeft.position, Quaternion.identity);
        Instantiate(slime, spawnRight.position, Quaternion.identity);
    }

    private void SpawnArrow()
    {
        Instantiate(arrow, spawnMiddle.position, Quaternion.identity);
    }
}
