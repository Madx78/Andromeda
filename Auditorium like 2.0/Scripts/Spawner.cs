using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Members

    public GameObject particule;
    public float lifeTime = 3f;

    #endregion

    #region Private & Protected Members

    private Transform _transform;

    #endregion

    #region System

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        Instantiate(particule, _transform);
    }
    #endregion
}
