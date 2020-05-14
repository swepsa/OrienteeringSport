using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public void NextPressed()
    {
        LoadSceneCareer();
    }

    private void LoadSceneCareer()
    {
        //TODO что то будем передовать upgrade skills
        SceneManager.LoadScene("Career");
    }
}