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
                StartCoroutine(Hide());
                _gameController.SpawnEnemy();
                _cameraAtackMode.rect = new Rect(1, 0, 1, 1);
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

    
}
