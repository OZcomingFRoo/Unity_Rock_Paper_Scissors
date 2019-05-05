using UnityEngine;

public static class InputConfig
{
    public static KeyCode Rock = KeyCode.R;
    public static KeyCode Paper = KeyCode.P;
    public static KeyCode Scissors = KeyCode.S;

    public static void ResetToDefaultInput()
    {
        Rock = KeyCode.R;
        Paper = KeyCode.P;
        Scissors = KeyCode.S;
    }
}
