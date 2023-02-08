using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// �R�[�h�̗񋓌^
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
    /// �X�P�[���̗񋓌^ (12��)
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
