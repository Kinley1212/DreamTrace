using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public List<SuperPeople> peoples;

    public void AddPeople(SuperPeople people)
    {
        peoples.Add(people);
    }

    public void RemovePeople(SuperPeople newPeople)
    {
        peoples.Remove(newPeople);
    }

    public void AddPeople(string name, int age, int id)
    {
        SuperPeople people = new SuperPeople();
        people.age = age;
        people.id = id;
        people.name = name;

      
        
        AddPeople(people);
    }

    public static void ShowAddNumber(int a, int b)
    {
        int n = a + b;
        Debug.Log("Êý×ÖÎª" + n);
    }
}
