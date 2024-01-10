using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [Header("Properties")]
    public int Level = 0;
    public LoadingBar Bar;
    public bool InTeleport = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            InTeleport = true;
            StartCoroutine(WaitForPlayerStay());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTeleport = false;
        }

    }

    public IEnumerator WaitForPlayerStay()
    {

        yield return new WaitForSeconds(1);

        if (InTeleport)
        {
            Bar.gameObject.SetActive(true);
            StartCoroutine(LoadLevel(Level));
        }

    }

    public IEnumerator LoadLevel(int level)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);

        while (!asyncLoad.isDone)
        {
            Bar.UpdateBar(asyncLoad.progress, 100.0f);
            yield return null;
        }

    }
}
