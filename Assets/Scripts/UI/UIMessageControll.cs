using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessageControll : MonoBehaviour
{
    [SerializeField] private float _id;
    private float id 
    {
        get { return _id; }
        set 
        {
            _id = value;
            Check();
        }
    }

    [SerializeField] Text[] _text;
    [SerializeField] Material _material;
    [SerializeField] Camera _cameraAtackMode;
    [SerializeField] GameController _gameController;

    public void SetId(float _id) 
    {
        id = _id;
    }

    public void Add() 
    {
        id ++;
    }

    public void Hiden() 
    {
        StartCoroutine(Hide());
        StartCoroutine(ShowAtackCameraMode());
    }   
    public void Showing() 
    {
        StartCoroutine(Show());
        StartCoroutine(HideAtackCameraMode());
    }

    private void Check() 
    {
        switch (id) 
        {
            case 1:
                Write("Captain", id);
                break;           
            case 2:
                Write("They are attacking us", id);
                break;
            case 3:
                StartCoroutine(HideAndShow());
                _gameController.SpawnEnemy();
                break;
            case 4:
                Write("You did it", id);
                break; 
            case 5:
                Write("But now is not the time to rejoice", id);
                break;         
            case 6:
                Write("We need to get into the safe sector", id);
                break;                       
            case 7:
                StartCoroutine(Hide());
                break;            
        }
    }

    private void Write(string text, float _id) 
    {
        _text[1].text = "";
        StartCoroutine(TextCoroutine(text, _id));
    }

    IEnumerator TextCoroutine(string text, float _id)
    {
        foreach (char c in text)
        {
            if (id != _id) 
            {
                break;
            }
            _text[1].text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator HideAndShow() 
    {

        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].GetComponent<Animator>().Play("TextHide");
        }
        float fade = 1;
        GetComponent<Image>().material = _material;
        while (true)
        {
            fade -= 0.01f;
            _material.SetFloat("_Fade", fade);
            if (fade <= 0)
            {
                StartCoroutine(ShowAtackCameraMode());
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Hide()
    {

        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].GetComponent<Animator>().Play("TextHide");
        }
        float fade = 1;
        GetComponent<Image>().material = _material;
        while (true)
        {
            fade -= 0.01f;
            _material.SetFloat("_Fade", fade);
            if (fade <= 0)
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Show() 
    {

        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].GetComponent<Animator>().Play("TextShow");
        }
        float fade = _material.GetFloat("_Fade");
        GetComponent<Image>().material = _material;
        while (true)
        {
            fade += 0.01f;
            _material.SetFloat("_Fade", fade);
            if (fade >= 1)
            {
                GetComponent<Image>().material = null;
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ShowAtackCameraMode() 
    {
        float _show = 1;
        while (true)
        {
            _show -= 0.01f;
            _cameraAtackMode.rect = new Rect(_show, 0, 1, 1);
            if (_show <= 0.5f)
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator HideAtackCameraMode()
    {
        float _show = 0.5f;
        while (true)
        {
            _show += 0.01f;
            _cameraAtackMode.rect = new Rect(_show, 0, 1, 1);
            if (_show >= 1)
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }


}
