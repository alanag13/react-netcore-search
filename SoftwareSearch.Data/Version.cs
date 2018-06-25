using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftwareSearch.Data
{
    public struct Version
    {
        readonly int Major;
        readonly int Minor;
        readonly int Revision;

        public Version(int major, int minor, int revision)
        {
            this.Major = major;
            this.Minor = minor;
            this.Revision = revision;

        }

        public bool IsLessThan(Version compared)
        {
            return !(IsGreaterThan(compared) || IsEqualTo(compared));
        }

        public bool IsGreaterThan(Version compared)
        {
            if (this.Major > compared.Major) return true;
            //if the previous int was less, then the rest of the numbers don't matter -- only check other numbers if it was equal
            if (this.Major == compared.Major && this.Minor > compared.Minor) return true;
            if (this.Major == compared.Major && this.Minor == compared.Minor && this.Revision > compared.Revision) return true;

            return false;
        }

        public bool IsEqualTo(Version compared)
        {
            return this.Major == compared.Major &&
                   this.Minor == compared.Minor &&
                   this.Revision == compared.Revision;
        }

        public static Version BuildFromString(string versionNumber)
        {
            var versionParts = versionNumber.Split('.');
            //allow trailing dots or multiple sequential dots
            versionParts = versionParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var numParts = versionParts.Length;
            var valid = true;
            int major = 0;
            int minor = 0;
            int revision = 0;

            if(numParts > 0)
            {
                valid = System.Int32.TryParse(versionParts[0], out major);
            }
            else
            {
                valid = false;
            }

            if (numParts > 1)
            {
                valid = System.Int32.TryParse(versionParts[1], out minor);
            }

            if (numParts > 2)
            {
                valid = System.Int32.TryParse(versionParts[2], out revision);
            }

            if (numParts > 3)
            {
                valid = false;
            }

            if (!valid)
            {
                throw new System.Exception("Invalid version number");
            }

            return new Version(major, minor, revision);
        }
    }




}
