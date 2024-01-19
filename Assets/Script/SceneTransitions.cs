using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadScene());
    }

    public void NextScene()
    {
        StartCoroutine(LoadScene());
    }

    public void GetScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
