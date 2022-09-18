using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Spawner : CharacterGenerator
{
    public Transform[] civSpawns;
    public Transform[] hosSpawns;

    public override void Awake()
    {
        
    }

    void spawnCivs()
    {
        /*
         * for each transform civSpawns (x% chance) //x% chance randomizes which civSpawns are used, making level slightly different each time
         *                  GenerateChar method 
         */
    }
}
