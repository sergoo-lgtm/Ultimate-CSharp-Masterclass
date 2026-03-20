using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Leage;

internal class Team
{
    public int TeamId { get; private set; }
    public string Name { get; private set; }
    public DateTime CreationDate { get; private set; }
    
    public string Description { get; private set; }

    public Team(string teamName, string description)
    {
        SetName(teamName); 

        CreationDate = DateTime.Now;

        SetDescription(description);

    }

    public void UpdateName(string newName)
    {
        SetName(newName);
    }

    private void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new Exception("Team name is required");

        Name = newName;
    }
    public void UpdateDescription(string newDescription)
    {
        SetDescription(newDescription);
    }
    
    private void SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new Exception("description is required");
        

        Description = newDescription;
    }


}
