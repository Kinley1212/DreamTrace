using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StudentManager : MonoBehaviour
{

    public Student[] aStudent;
    public string name;
    private void Start()
    {
        FindOutput(name);
        aStudent[0].改名(name);

        Student student = new Student();
        student.移动();
        Debug.Log(Student.学生几条腿());
    }

    public void FindOutput(string name)
    {
        foreach (Student student in aStudent)
        {
            if (student.名字 == name)
            {
                Debug.Log(student.分数);
                Debug.Log(student.性别);
            }
        }
    }
}
