//struct is a valid data type where data is passed as a copy. Classes use references.
//
// Using copies allows us to alter the data without affecting the original. References cause us to directly alter the original
//

public struct GridPosition
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
        return "x: " + x + "; z: " + z + ";";
    }

}