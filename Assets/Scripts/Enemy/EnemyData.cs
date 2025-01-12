using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    public float Speed { get; private set; }  //movementSpeed of the enemy

    public List<Color> Colors { get; private set; } = new List<Color> { Color.white, Color.blue, Color.yellow };

    Color[] TowerColorList { get; } = { new Color(1, 0, 0), new Color(1, 1, 0), new Color(0, 0, 1) };
    Color[] EnemyColorList { get; } = { new Color(0, 1, 0), new Color(1, 0.6f, 0), new Color(0.6f, 0, 1) };
    TypeEnemy MyType;
    Color MyColor; //the color of the enemy
    int Health = 0;

    SpriteRenderer border;
    SpriteRenderer inside;
    float healthRemoveAmount;
    Color currentColor;
    Color tempColor;
    float[] coloredHealth;
    private int colorDevide;
    private int TEMPORARYINTFORDEBUG = 1;
    enum TypeEnemy
    {
        Normal, Big, Small
    }


    private void Start()
    {
        transform.Find("Border")?.TryGetComponent<SpriteRenderer>(out border);
        transform.Find("Inside")?.TryGetComponent<SpriteRenderer>(out inside);

        SpanWithRandomValues();

        // Colors colorIndex = (Colors)UnityEngine.Random.Range(0, EnemyColorList.Length);
        // TargetColor = EnemyColorList[(int)colorIndex];

        // inside.color = currentColor = Color.white;
        // border.color = TargetColor;

        //  Type = (TypeEnemy)UnityEngine.Random.Range(0, 3);


        // HpValues[2] = health;
        //if (colorIndex == Colors.Green)
        //{
        //    HpValues[(int)TowerColors.Yellow] = health;
        //    HpValues[(int)TowerColors.Blue] = health;
        //} else if (colorIndex == Colors.Purple)
        //{
        //    HpValues[(int)TowerColors.Red] = health;
        //    HpValues[(int)TowerColors.Blue] = health;
        //} else if (colorIndex == Colors.Orange)
        //{
        //    HpValues[(int)TowerColors.Yellow] = health;
        //    HpValues[(int)TowerColors.Red] = health;
        //} else
        //{
        //    print("NoColorIndexException");
        //}
        //colorDevide = 4;//helth;

    }

    private void SpanWithRandomValues()
    {
        // set color and speed enz.
        var index = UnityEngine.Random.Range(0, 3);
        MyColor = Colors[index];
        MyType = (TypeEnemy)index;

        var settings = GetHealthAndSpeedFromType(MyType);
        Speed = settings.speed;
        Health = settings.health;

        inside.color = MyColor;
    }

    private (int health, float speed) GetHealthAndSpeedFromType(TypeEnemy typeEnemy)
    {
        int health = 0;
        float speed = 0;

        switch (typeEnemy)
        {
            case TypeEnemy.Normal:
                speed = 2f * TEMPORARYINTFORDEBUG;
                health = 2;
                break;
            case TypeEnemy.Big:
                speed = 1f * TEMPORARYINTFORDEBUG;
                health = 4;
                break;
            case TypeEnemy.Small:
                speed = 3f * TEMPORARYINTFORDEBUG;
                health = 1;
                break;
            default:
                Debug.LogError($"invalid enemyType:{MyType}");
                break;
        }
        return new(health, speed);
    }

    private void Update()
    {
        if (Health <= 0)
        {
            EnemyWaves.EnemyDestroyed("Player", gameObject);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("pressed");
        //    TakeDamage(TowerColors.Yellow);  
        //}

        //if (Input.GetMouseButtonDown(1)) 
        //{
        //    print("pressed");
        //    TakeDamage(TowerColors.Red);
        //}
    }
    public void TakeDamage(Color color)
    {

        if (MyColor == color) {
            Health--;
        }

       // HpValues[(int)color] -= 1;
        //print(HpValues[(int)color]);
        //HpValues[HpValues.ElementAt((int)color).Key] -= 1;
        //float flippedValue = colorDevide - HpValues[HpValues.ElementAt((int)color).Key];
        //Color colorMultiplier = (TowerColorList[(int)color] / colorDevide) * flippedValue;
        //currentColor = Color.Lerp(colorMultiplier, currentColor, 1);
        //inside.color = color;
    }
}
