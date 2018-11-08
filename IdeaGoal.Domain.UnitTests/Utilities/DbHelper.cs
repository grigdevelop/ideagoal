using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IdeaGoal.Domain.Core.Data;

namespace IdeaGoal.Domain.UnitTests.Utilities
{
    public class DbHelper
    {
        public static void CleanDb(IdeaGoalDbContext db)
        {
            db.UserTokens.RemoveRange(db.UserTokens.ToList());
            db.SaveChanges();

            db.Ideas.RemoveRange(db.Ideas.ToList());
            db.SaveChanges();

            db.Users.RemoveRange(db.Users.ToList());
            db.SaveChanges();            
        }

        public static void Execute()
        {
            //var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory.ToString()).
            //    Parent.Parent.Parent.Parent.GetDirectories("IdeaGoal.Database")[0];
            //var file = dir.GetFiles("update.ps1")[0];
            //PowerShell.RunPowerShell rp = new PowerShell.RunPowerShell();
            //var result = File.ReadAllText(file.FullName).Replace(@"${pdir}", dir.ToString());
            //var pResult = rp.InvokePS(result);
        }
    }
}
