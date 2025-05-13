//struct is a valid data type where data is passed as a copy. Classes use references.
//
// Using copies allows us to alter the data without affecting the original. References cause us to directly alter the original
//


// This script is for finding and returning the position values an object is located at
using System;

public struct GridPosition : IEquatable<GridPosition>
{
    public int x; 
    public int z;

    public GridPosition(int x, int z)
    {
        this.x = x; 
        this.z = z;
    }

    public override string ToString()
    {
        return $"x: {x}; z: {z}";
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    //override the != operator to compare two grid positions
    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    //override the == operator to compare two grid positions
    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

}