using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Student
{
    //成员
    public string 名字;
    public float 分数;
    public bool 性别; //true 男


    public static int handcount = 3;
    //变量

    public static string 学生几条腿()
    {
        return "两条腿";
    }
    //方法

    public void Add(float 加的分)
    {
        分数 += 加的分;
    }

    public void 改名(string 新名字)
    {
        名字 = 新名字;
    }
    public void 改数据(string 新名字, float 新分数, bool 新性别 = true)
    {
        名字 = 新名字;
        分数 = 新分数;
    }

    public void 改数据(string 新名字)
    {
        名字 = 新名字;
    }

    public void 移动()
    { }
}
