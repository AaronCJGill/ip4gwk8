using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class jsonTranslator 
{
    public Prizes[] prizes;

}
[System.Serializable]

public class Prizes
{
    public string year;
    public string category;
    public List<Laureates> laureates;
    public string overallMotivation;
}

[System.Serializable]

//"prizes":[{
//"year":"2023","category":"chemistry","laureates":[{ "id":"1029","firstname":"Moungi",
//"surname":"Bawendi","motivation":"\"for the discovery and synthesis of quantum dots\"","share":"3"}
public class Laureates
{
    public string id;
    public string firstname;
    public string surname;
    public string motivation;
    public string share;
}