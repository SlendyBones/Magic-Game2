using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Sliders")]
    [SerializeField] private Slider _hSlider, _mSlider;
    [SerializeField] private Gradient _hGradient, _mGradient;
    [SerializeField] private Image _hFill, _mFill;

    public void SetMaxHealth(float maxVar)
    {
        _hSlider.maxValue = maxVar;
        _hSlider.value = maxVar;

        _hFill.color = _hGradient.Evaluate(1f);
    }

    public void SetMaxMana(float maxVar)
    {
        _mSlider.maxValue = maxVar;
        _mSlider.value = maxVar;

        _mFill.color = _mGradient.Evaluate(1f);
    }

    public void SetHealth(float actualVar)
    {
        _hSlider.value = actualVar;

        _hFill.color = _hGradient.Evaluate(_hSlider.normalizedValue);
    }

    public void SetMana(float actualVar)
    {
        _mSlider.value = actualVar;

        _mFill.color = _mGradient.Evaluate(_mSlider.normalizedValue);
    }


    [Header("Abilities")]
    [SerializeField] private List<Image> _abilitiesImage;
    [SerializeField] public List<bool> _isCD;
    [SerializeField] private List<float> _cooldown;

    private void Start()
    {
        for (int i = 0; i < _abilitiesImage.Count; i++)
        {
            _abilitiesImage[i].fillAmount = 0;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _isCD.Count; i++)
        {
            if(_isCD[i] == true)
            {
                _abilitiesImage[i].fillAmount -= 1 / _cooldown[i] * Time.deltaTime;
                if (_abilitiesImage[i].fillAmount <= 0)
                {
                    _abilitiesImage[i].fillAmount = 0;
                    _isCD[i] = false;
                }
            }
        }
    }

    public void SetOff(int image)
    {
        _abilitiesImage[image].fillAmount = 1;
        _isCD[image] = true;
    }
}
