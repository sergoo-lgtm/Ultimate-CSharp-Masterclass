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

    private Team()
    {

    }

    public Team(string teamName, string description)
    {
        SetName(teamName);

        CreationDate = DateTime.Now;

        SetDescription(description);

    }

    public void Update(string? newName=null, string? newDescription=null)
    {
        if(newName != null)
            SetName(newName);

        if (newDescription != null)
            SetDescription(newDescription);

    }
   

    private void SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Team name is required");

        Name = newName;
    }





    private void SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException("description is required");


        Description = newDescription;
    }


}
