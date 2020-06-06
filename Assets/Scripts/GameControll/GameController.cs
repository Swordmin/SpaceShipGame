using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;
    [SerializeField] float waveCount;
    [SerializeField] float money;
    [SerializeField] Camera cameraAtackMode;
    [SerializeField] Text moneyCountText;
    [SerializeField] UIMessageControll _uiMessageControll;

    public Image healthBar;

    private void Start()
    {
    }

    public void SpawnEnemy() 
    {
        if (waveCount > 0)
        {
            GameObject enemyObj = Instantiate(enemy, spawnPos.position, enemy.transform.rotation);
            Enemy _enemy = enemyObj.GetComponent<Enemy>();
            _enemy.healthBar = healthBar;
            _enemy.healthBar.fillAmount = _enemy._baseEnemy.GetHealth(0) / 100;
            waveCount -= 1;
        }
        else 
        {
            _uiMessageControll.Showing();
            _uiMessageControll.SetId(4);
        }
    }


    public float GetMoney(float _money) 
    {
        return money;
    }
    public void SetMoney(float _money) 
    {
        Debug.Log("fd");
        money += _money;
        moneyCountText.text = "Money " + money;
    }

}
