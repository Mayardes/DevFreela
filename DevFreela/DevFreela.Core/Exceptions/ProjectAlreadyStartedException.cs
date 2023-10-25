namespace DevFreela.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException(): base("project is already in Started Status.")
    {
    }
}