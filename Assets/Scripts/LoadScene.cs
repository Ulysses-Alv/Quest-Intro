using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private bool isChanging;
    private void Awake()
    {
        isChanging = false;
    }
    public void ChangeScene()
    {
        if (isChanging) return;

        isChanging = true;
        FadeController.instance.DoFadeOut();
        StartCoroutine(LoadGameScene());
    }
    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("Shooter");
    }
}
