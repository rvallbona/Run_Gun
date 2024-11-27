using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void AnimButton(GameObject anim)
    {
        anim.SetActive(true);
    }
    public void ChangeScene(string namescene)
    {
        SceneManager.LoadScene(namescene);
    }

}
