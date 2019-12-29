using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithTime : MonoBehaviour {
    public int i;
    public float waitTime;

    void Update()
    {
        LoadSceneNumberFromArr(i);
    }

    public void LoadSceneNumberFromArr(int i)
    {

        if (Time.timeSinceLevelLoad >= waitTime)
        {

            Debug.Log("sceneBuildIndex to load: " + i);
            SceneManager.LoadScene(i);
        }
    }
}