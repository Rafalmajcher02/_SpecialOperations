using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public Sprite[] head;
    public Sprite[] body;
    public Sprite[] allBody;

    public virtual void Awake()
    {
        GenerateChar();
    }
    void GenerateChar()
    {
        //Chose A or B
        int xNom = Random.Range(0, 1);

        //A will be for generating random civ's head and body from selection of sprites
        if (xNom == 0)
        {
            int xNomHead = Random.Range(0, head.Length);
            int xNomBody = Random.Range(0, body.Length);
        }
        //B will be for generating a whole civ in premade costume from selection of sprites
        else
        {
            int xNomAllBody = Random.Range(0, allBody.Length);
        }
    }

}
