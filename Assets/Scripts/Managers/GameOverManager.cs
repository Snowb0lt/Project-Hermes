using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject BadEndText;
    [SerializeField] private Animator BadEndTextAnim;

    [SerializeField] private AudioSource Thud;

    private void Start()
    {
        BadEndTextAnim = BadEndText.GetComponent<Animator>();
        BadEndTextAnim.SetBool("IsPlaying", false);
        Invoke("StoryTextFadeIn", 3);
        Invoke("GameOverFadeIn", 6);
    }
    private void StoryTextFadeIn()
    {
        BadEndTextAnim.SetBool("IsPlaying", true);
    }
    private void GameOverFadeIn()
    {
        GameOverText.SetActive(true);
        MenuButton.SetActive(true);
        Thud.Play();
    }

}
