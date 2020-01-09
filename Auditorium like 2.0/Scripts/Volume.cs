using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    #region Public Members

    public GameObject circleFull;
    public GameObject musicFull;
    public float musicAmount = 0f;

    #endregion

    #region Private & Protected Members

    private float _hitNumber =0f;
    private float _fillAmount = 0f;
    private float _volume = 0f;
    private float _musicAmount;
    

    private AudioSource _audioSource;
    private Image _circleFullAmount;
    private Image _musicFullAmount;

    [SerializeField]
    private float _decreaseSpeed = 5f;
    [SerializeField]
    private float _increaseSpeed = 100f;

    #endregion


    #region System

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _circleFullAmount = circleFull.GetComponent<Image>();
        _musicFullAmount = musicFull.GetComponent<Image>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Particule"))
        {
            _hitNumber++;
        }


        if (_fillAmount > 1)
        {
            _musicAmount++;

        }
    }



    private void Update()
    {
        musicAmount = _musicAmount / _increaseSpeed;
      

        // hit Number decrease over time
        if(_hitNumber > 0 && _musicAmount <=0)
        {
        _hitNumber -= Time.deltaTime*_decreaseSpeed;
        }

        //music Amount decrease over time
        if (_musicAmount > 0)
        {
            _musicAmount -= Time.deltaTime * _decreaseSpeed;
        }

        //Audio source volume controler
        _volume = _hitNumber/ _increaseSpeed;
        _audioSource.volume = _volume;

        // fill Amount increasing
        _circleFullAmount.fillAmount = _fillAmount;
        _fillAmount = _hitNumber / _increaseSpeed;
        _musicFullAmount.fillAmount = musicAmount;
    }

    #endregion
}
