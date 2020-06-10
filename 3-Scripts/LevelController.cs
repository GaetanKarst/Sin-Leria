using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    public int numberOfAttackers = 0;
    bool levelTimerHasFinished = false;

    [SerializeField] float timeToWaitForNextScene = 3f;

    LifeDisplay life;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
         life = FindObjectOfType<LifeDisplay>();
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerHasFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        loseLabel.SetActive(false);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeToWaitForNextScene);
        GetComponent<LevelLoader>().loadNextScene();
    }


    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        winLabel.SetActive(false);
        Time.timeScale = 0.4f;
    }

    public void LevelTimerFinished()
    {
        levelTimerHasFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
