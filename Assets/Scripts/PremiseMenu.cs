using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PremiseMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> storytexts = new List<GameObject>();
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Animator blackScreenAnim;
    private int slideNumber = 1;

    private NavigationManager navManager;

    private void Awake()
    {
        navManager = GameObject.FindObjectOfType<NavigationManager>().GetComponent<NavigationManager>();
    }

    public void ShowButton()
    {
        nextButton.SetActive(true);
    }

    public void Start()
    {
        Invoke("ShowButton", 3);
    }

    public void ButtonActions()
    {
        nextButton.SetActive(false);
        if (storytexts[1].activeInHierarchy == true)
        {
            blackScreenAnim.SetBool("ShowImage", true);
            blackScreenAnim.SetBool("FadeToBlack", false);
        }
        if (storytexts[4].activeInHierarchy == true)
        {
            buttonText.text = "Let's Go!";
        }
        if (storytexts[5].activeInHierarchy == true)
        {
            navManager.NewRun();
        }
        NextSlide();
        Invoke("ShowButton", 3);
    }

    public void NextSlide()
    {
        storytexts[slideNumber].SetActive(false);
        storytexts[slideNumber+1].SetActive(true);
        slideNumber++;
    }
}
