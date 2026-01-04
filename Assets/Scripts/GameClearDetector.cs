using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        // すべてのボールが入ったラベルを表示
        if (holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
        }
    }
}
