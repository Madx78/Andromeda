using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleBehaviour : MonoBehaviour
{
    #region Private & Protected Members

    [SerializeField] private GameObject _spawner;
    [SerializeField] private float _lifeTime;

    #endregion

    #region System
    private void Awake()
    {
        _spawner = GameObject.Find("Spawner");   
        _lifeTime = _spawner.GetComponent<Spawner>().lifeTime;
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    #endregion
}
