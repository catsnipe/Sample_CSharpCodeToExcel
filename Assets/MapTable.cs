using System.Collections.Generic;
using UnityEngine;

public enum eMapObject
{
    None,
    Wall,
    Wall1,
    Wall2,
    Wall3,
    WallLine,
    TrapLine,
    CubeLine,
    Enemy00,
    Fixed00,
};

/// <summary>
/// MapTable (Sample)
/// </summary>
public class MapTable : ScriptableObject
{
    ///<summary>
    /// Table Row
    ///</summary>
    [System.Serializable]
    public class Row
    {
        public int          ID;
        public eMapObject   Type;
        public int          StageNo;
    };

    /// <summary>
    /// テーブルデータ
    /// </summary>
    public static List<Row> Rows = new List<Row>()
    {
        new Row() {ID = 1, Type = eMapObject.Wall,     StageNo = 1},
        new Row() {ID = 2, Type = eMapObject.WallLine, StageNo = 1},
        new Row() {ID = 3, Type = eMapObject.Enemy00,  StageNo = 1},
        new Row() {ID = 4, Type = eMapObject.Wall,     StageNo = 2},
        new Row() {ID = 5, Type = eMapObject.Wall,     StageNo = 3}
    };
}
