using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// コードの列挙型
    /// </summary>
    public enum Chords
    {
        None,
        A,
        Am,
        A_,
        A_m,
        B,
        Bm,
        C,
        Cm,
        C_,
        C_m,
        D,
        Dm,
        D_,
        D_m,
        E,
        Em,
        F,
        Fm,
        F_,
        F_m,
        G,
        Gm,
        G_,
        G_m
    }

    /// <summary>
    /// スケールの列挙型 (12種)
    /// </summary>
    public enum Scale
    {
        None,
        Major,
        NaturalMinor,
        Lydian,
        Dorian
    }

    public enum Key
    {
        None,
        A,
        A_,
        B,
        C,
        C_,
        D,
        D_,
        E,
        F,
        F_,
        G,
        G_
    }
}
