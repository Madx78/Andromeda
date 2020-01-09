using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    public GameObject winScreen;

#region Private & Protected Members
    
    private int _AudioAreaNumber;
    [SerializeField]
    private GameObject[] _AudioAreas;
 
    private int _actualIndex;
    private int _activeArea = 0;
    #endregion

    #region system
    private void Start()
    {
        _AudioAreaNumber = _AudioAreas.Length;
        _actualIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        _activeArea = 0;
        foreach (GameObject _audioArea in _AudioAreas)
        {
            if(_audioArea.GetComponent<Volume>().musicAmount >=1)
            {
                _activeArea++;
            }
        }

        if(_activeArea == _AudioAreaNumber)
        {
            Win();
        }

    }
    #endregion

    #region Main Methodes
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLv1()
    {
        SceneManager.LoadScene("Lv1");
    }

    public void Reload()
    {
        SceneManager.LoadScene(_actualIndex);
       
    }

    public void NextLv()
    {
        SceneManager.LoadScene(++_actualIndex);
        //SceneManager.LoadScene("Lv2");
    }

    public void Win()
    {
        winScreen.SetActive(true);
        gameObject.GetComponent<Animator>().SetTrigger("WinAnimation");
    }
    #endregion
}
