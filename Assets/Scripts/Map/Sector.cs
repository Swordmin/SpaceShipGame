using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sector : MonoBehaviour
{

    [SerializeField] private enum sectorType { enemy, magazine, save, basic};
    [SerializeField] private sectorType _sectorType;
    [SerializeField] private Text nameSector;

    private void Start()
    {
        _sectorType = (sectorType)Random.Range(0, System.Enum.GetValues(typeof(sectorType)).Length); //Выбираем рандомный тип ячейки
        InitializationSector();
    }

    private void InitializationSector() 
    {
        switch (_sectorType) 
        {
            case sectorType.enemy:
                SetSpriteColour(new Color(204,0,0), "danger");
                break;          
            case sectorType.magazine:
                SetSpriteColour(new Color(57,255,58), "shop");
                break;          
            case sectorType.save:
                SetSpriteColour(new Color(8,204,0), "save");
                break;           
            case sectorType.basic:
                SetSpriteColour(new Color(0,59,204), "basic");
                break;
        }
    }

    private void SetSpriteColour(Color _color, string _nameSector) 
    {
        GetComponent<Image>().color = _color;
        nameSector.text = _nameSector;
    }

}
