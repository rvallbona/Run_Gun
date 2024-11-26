using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject option1Button, option2Button, option3Button, option1Anim, option2Anim, option3Anim;
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
}
