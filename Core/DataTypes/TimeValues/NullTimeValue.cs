namespace Core.DataTypes.TimeValues;

public class NullTimeValue : ITimeValue {

    public float Seconds => 0;

    public NullTimeValue() {
        
    }

    public override string ToString() {
        return "NullTimeValue";
    }

}