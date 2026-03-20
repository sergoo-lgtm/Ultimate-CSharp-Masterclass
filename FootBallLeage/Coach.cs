internal class Coach
{
    public int CoachId { get; private set; }
    public string Name { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Description { get; private set; }

    public Coach(string coachName, string description)
    {
        SetName(coachName);
        SetDescription(description);
        CreationDate = DateTime.Now;
    }

    public void UpdateName(string newName)
    {
        SetName(newName);
    }

    public void UpdateDescription(string newDescription)
    {
        SetDescription(newDescription);
    }

    private void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new Exception("Coach name is required");

        Name = newName;
    }

    private void SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new Exception("Description is required");

        Description = newDescription;
    }
}