using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static string p1Select;
    public static string p2Select;
    public static string p3Select;
    public static string p4Select;

    public static int p1Team;
    public static int p2Team;
    public static int p3Team;
    public static int p4Team;

    public void P1CharacterSelect(string character)
    {
        p1Select = character;
    }

    public void P2CharacterSelect(string character)
    {
        p2Select = character;
    }

    public void P3CharacterSelect(string character)
    {
        p3Select = character;
    }

    public void P4CharacterSelect(string character)
    {
        p4Select = character;
    }


    public void P1TeamSelect(int team)
    {
        p1Team = team;
    }

    public void P2TeamSelect(int team)
    {
        p2Team = team;
    }

    public void P3TeamSelect(int team)
    {
        p3Team = team;
    }

    public void P4TeamSelect(int team)
    {
        p4Team = team;
    }
}
