using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmoothLoader : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadLevel(1);
        }
    }

    public void LoadLevel(int level)
    {
        StartCoroutine(loadingLevel(level));
    }

    private IEnumerator loadingLevel(int level)
    {
        _animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(level);
    }
}
