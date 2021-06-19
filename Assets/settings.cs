using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class settings : MonoBehaviour
{
    public Slider mainSlider; // nasz slajder do ustawiania predkosci
    public TMP_Dropdown m_Dropdown; //nasza wysuwana lista do ustawiania rozmiaru 
    

    public void Start() //domyslne ustawienie 
    {
        mainSlider.value = 0.8f;
        m_Dropdown.value = 1;
    }


    public void Quit() //wysylamy informacje do funkcji zmieniajacej ustawienia gry
    {

        Plansza.applySettings(mainSlider.value, m_Dropdown.value);
        SceneManager.LoadScene(0);
    }

}
