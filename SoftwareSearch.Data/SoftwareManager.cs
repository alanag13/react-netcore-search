using System.Collections.Generic;
using System.Linq;

public static class SoftwareManager
{
    public static IEnumerable<Software> GetAllSoftware()
    {
        return new List<Software>
            {
                new Software
                {
                    Name = "MS Word",
                    Version = "13.2.1."
                },
                new Software
                {
                    Name = "Angular1",
                    Version = "1.0.9"
                },
                new Software
                {
                    Name = "Angular2",
                    Version = "2"
                },
                new Software
                {
                    Name = "Doom",
                    Version = "0.0.5"
                },
                new Software
                {
                    Name = "Clippy",
                    Version = "2.1"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new Software
                {
                    Name = "Sublime3",
                    Version = "3.9"
                },
                new Software
                {
                    Name = "Call of Duty",
                    Version = "9.9.9"
                }
            };

    }
    public static IEnumerable<Software> GetAllSoftwareWithHigherVersion(string versionNumber)
    {
        var inputVersion = SoftwareSearch.Data.Version.BuildFromString(versionNumber);
        return GetAllSoftware().Where((x) => SoftwareSearch.Data.Version.BuildFromString(x.Version).IsGreaterThan(inputVersion));
    }
}