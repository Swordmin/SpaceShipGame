using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Test : MonoBehaviour
{
    Animal animal = new Animal();
    Dog dog = new Dog();
    Cat cat = new Cat();

    private void Start()
    {
        animal.Action();
        dog.Action();
        cat.Action();
    }

}

public class Animal 
{
    public virtual void Action() 
    {
        Debug.Log("One");
    }
}

public class Dog : Animal 
{
    public override void Action()
    {
        Debug.Log("Dog");
    }
}
public class Cat : Animal 
{
    public override void Action()
    {
        Debug.Log("Cat");
    }
}
