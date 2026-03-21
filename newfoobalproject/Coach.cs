internal class Coach
{
    public int CoachId { get; private set; }
    public string Name { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Description { get; private set; }

    private Coach()
    {

    }

    public Coach(string coachName, string description)
    {
        SetName(coachName);
        SetDescription(description);
        CreationDate = DateTime.Now;
    }

    public void Update(string? newName = null,string? newDescription=null)
    {
        if (newName != null)
        {
            SetName(newName);
        }
        if(newDescription != null)
        SetDescription(newDescription);
    }


    private void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Coach name is required");

        Name = newName;
    }

    private void SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException("Description is required");

        Description = newDescription;
    }
}