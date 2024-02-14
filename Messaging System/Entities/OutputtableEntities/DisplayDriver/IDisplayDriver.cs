namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.DisplayDriver;

public interface IDisplayDriver
{
    void ClearOutput();
    public void WriteMessage(string message);
}