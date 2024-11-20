using UnityEngine;
[System.Flags]
public enum EnumTag {
    None = 0,
    Untagged = 1 << 0,
    Respawn = 1 << 1,
    Finish = 1 << 2,
    EditorOnly = 1 << 3,
    MainCamera = 1 << 4,
    Player = 1 << 5,
    GameController = 1 << 6,
    Tag = 1 << 7,
    PlayerPickUpPoint = 1 << 8,
    SuckAndPickup = 1 << 9,
    Suckable = 1 << 10,
    Door = 1 << 11,
    Elevator = 1 << 12,
    Trap = 1 << 13,
    Push = 1 << 14,
}
