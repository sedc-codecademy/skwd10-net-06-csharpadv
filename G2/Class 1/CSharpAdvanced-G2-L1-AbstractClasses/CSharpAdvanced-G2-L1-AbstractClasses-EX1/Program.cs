using CSharpAdvanced_G2_L1_AbstractClasses_EX1.Entities;


List<Developer> developers = new List<Developer>()
{
    new Developer(1, "Mihajlo", "Dimovski", 32, "FitXP"),
    new Developer(2, "Bojan", "Damcevski", 40, "ProOffice"),
    new Developer(3, "Ivan", "Dzikovski", 32, "E-Health")
};

TeamLead teamLead = new TeamLead(4, "Team", "Leader", 45, "Everywhere", developers);

Developer developer = developers.First();

developer.Work();

teamLead.Work();

HR hr = new HR(5, "Ana", "Kadrovo", 40, 2);

hr.Work();

hr.Recruit(teamLead);